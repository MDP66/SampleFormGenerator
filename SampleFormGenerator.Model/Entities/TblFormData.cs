using SampleFormGenerator.Model.Contracts;
using System;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormData : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_FormInfo { get; set; }
    }
}
