﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardBackend.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeOfCompany { get; set; }
        public string CVR { get; set; }


        public virtual User User { get; set; }

    }
}
