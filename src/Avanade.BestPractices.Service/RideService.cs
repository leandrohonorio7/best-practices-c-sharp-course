using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Entities.Enums;
using Avanade.BestPractices.Domain.Entities.Exceptions;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Domain.Interfaces.Services;
using Avanade.BestPractices.Domain.ValueObjects;
using Avanade.BestPractices.Service.Core;
using Avanade.BestPractices.Service.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Service
{
    public class RideService : ServiceBase<Ride>, IRideService
    {
        private readonly IRideRepository _rideRepository;
        private readonly IAccountService _accountService;
        private readonly IVehicleService _vehicleService;

        public RideService(IRideRepository rideRepository,
            IAccountService accountService,
            IVehicleService vehicleService)
        {
            _rideRepository = rideRepository;
            _accountService = accountService;
            _vehicleService = vehicleService;
        }

        public async Task FinishAsync(Guid rideId)
        {
            var ride = await GetByIdAsync(rideId);
            if (ride is null)
                throw new NullReferenceException(RideErrorCode.R001.Code);

            if (ride.EndAt.HasValue)
                throw new InvalidOperationException(RideErrorCode.R003.Code);

            ride.EndAt = DateTime.UtcNow;
            ride.Distance = DateTime.UtcNow.Millisecond; //Mock

            var charge = new Charge
            {
                GrossValue = new Money
                {
                    Currency = "BRL",
                    Value = 10 * DateTime.UtcNow.Millisecond //Mock
                },
                Description = "Valor da corrida"
            };
            charge.CalculateNetValue();
            ride.Charges = new List<Charge> 
            {
                charge 
            };

            var validator = new RideValidator();
            await validator.ValidateAndThrowAsync(ride);

            _rideRepository.Update(ride);
            await _rideRepository.SaveChangesAsync();

            await _vehicleService.SetIsAvailableAsync(ride.VehicleId, true);
        }

        public Task<Ride> GetByIdAsync(Guid id)
        {
            return _rideRepository.GetByIdAsync(id);
        }

        public Task<Ride> GetCurrentAsync(Guid accountId)
        {
            return _rideRepository.GetCurrentAsync(accountId);
        }

        public async Task<Ride> StartAsync(Guid vehicleId, Guid accountId)
        {
            var currentRide = await GetCurrentAsync(accountId);
            if (currentRide is not null)
                throw new InvalidOperationException(RideErrorCode.R002.Code);

            var account = await _accountService.GetByIdAsync(accountId);
            if (account is null)
                throw new NullReferenceException(AccountErrorCode.A001.Code);

            if (!account.IsApproved)
                throw new InvalidOperationException(AccountErrorCode.A002.Code);

            var vehicle = await _vehicleService.GetByIdAsync(vehicleId);
            if (vehicle is null)
                throw new NullReferenceException(VehicleErrorCode.V001.Code);

            if (!vehicle.IsAvailable)
                throw new InvalidOperationException(VehicleErrorCode.V002.Code);

            var ride = new Ride()
            {
                AccountId = accountId,
                VehicleId = vehicleId,
                StartAt = DateTime.UtcNow,
            };

            var validator = new RideValidator();
            await validator.ValidateAndThrowAsync(ride);

            await _rideRepository.AddAsync(ride);
            await _rideRepository.SaveChangesAsync();

            await _vehicleService.SetIsAvailableAsync(vehicleId, false);

            return ride;
        }
    }
}
