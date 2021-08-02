﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Request
{
    public class PersonRequest
    {

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        
        public string Email { get; set; }

        
        public string Company { get; set; }
        //[Required]
        public int Age { get; set; }
        
    }
}
