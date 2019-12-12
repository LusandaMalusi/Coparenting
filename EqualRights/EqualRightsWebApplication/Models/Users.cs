﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EqualRightsWebApplication.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contacts { get; set; }
        public string Email { get; set; }
        public string Maintanance { get; set; }
        public string Reviews { get; set; }
        public DateTime DateVisit { get; set; }
        public bool Posted { get; set; }
    }
}
