﻿using SampleFormGenerator.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormData : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_FormInfo { get; set; }
    }
}
