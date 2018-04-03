using SampleFormGenerator.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormInfos : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}
