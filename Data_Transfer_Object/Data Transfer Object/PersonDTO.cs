﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data_Transfer_Object
{
    public class PersonDTO
    {
        public int PersonID {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}