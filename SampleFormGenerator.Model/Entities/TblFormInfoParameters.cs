using SampleFormGenerator.Model.Contracts;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormInfoParameters : IEntity
    {
        public int Id_FormInfo { get; set; }
        public int Id_ParameterTypes { get; set; }
        public string ParamterTitle { get; set; }
        public bool IsMandotory { get; set; }
        public short ParameterOrder { get; set; }
    }
}
