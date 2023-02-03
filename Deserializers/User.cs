﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AlzaTest.Deserializers
{
    public class User
    {
        public string? name { get; set; }
        public string? image { get; set; }
        public string? description { get; set; }
        public string? linkedInUrl { get; set; }

    }

}
