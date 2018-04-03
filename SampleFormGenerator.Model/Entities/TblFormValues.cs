using SampleFormGenerator.Model.Contracts;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormValues : IEntity
    {
        public int Id { get; set; }
        public int Id_FormInfoParamater { get; set; }
        public int Id_FormData { get; set; }
        public string Value { get; set; }
        public bool IsValidationPassed { get; set; }
    }
}
