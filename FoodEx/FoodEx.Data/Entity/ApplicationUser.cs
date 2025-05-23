﻿using FoodEx.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}