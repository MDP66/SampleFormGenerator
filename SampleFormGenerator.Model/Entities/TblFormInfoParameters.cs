using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormInfoParameters
    {
        public int Id_FormInfo { get; set; }
        public int Id_ParameterTypes { get; set; }
        public string ParamterTitle { get; set; }
        public bool IsMandotory { get; set; }
        public short ParameterOrder { get; set; }
    }
}
