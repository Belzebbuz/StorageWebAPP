﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWebAPP.Models
{
    public class Nomenclature
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Unit { get; set; }

    }
}