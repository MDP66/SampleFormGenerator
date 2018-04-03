using SampleFormGenerator.Model.Contracts;

namespace SampleFormGenerator.Model.Entities
{
    public class TblParameterTypes : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RegexValidator { get; set; }
        public string RegexValidatorMessage { get; set; }
        public string EditorType { get; set; }
        public string ViewerType { get; set; }
    }
}
