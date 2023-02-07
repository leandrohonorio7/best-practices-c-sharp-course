using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models
{
    public class GenerateToken
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Verification { get; set; }
    }
}
