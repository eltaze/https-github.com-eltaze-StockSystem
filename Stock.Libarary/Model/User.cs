﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Right> Rights { get; set; } = new List<Right>();
    }
}
