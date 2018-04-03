using SampleFormGenerator.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormValues : IEntity
    {
        public int Id { get; set; }
        public int Id_ParameterTypeId { get; set; }
        public int Id_FormData { get; set; }
        public string Value { get; set; }
        public bool IsValidationPassed { get; set; }
    }
}
