using SampleFormGenerator.Model.Contracts;

namespace SampleFormGenerator.Model.Entities
{
    public class TblFormInfos : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}
