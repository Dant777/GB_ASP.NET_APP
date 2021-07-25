using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Request
{
    public class HospitalRequest
    {
        [Required]
        public string Name { get; set; }
        
    }
}
