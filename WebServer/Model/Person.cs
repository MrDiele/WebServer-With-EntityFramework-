﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Person
    {
        [Key]
        public int idperson { get; set; }
        public string name { get; set; }
        public DateTime dateofbirth { get; set; }
        [ForeignKey("idcity")]
        public City city { get; set; }
    }
}
