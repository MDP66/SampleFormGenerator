namespace SampleFormGenerator.Model.ViewModel
{
    public class vmParameters
    {
        public int Id { get; set; }
        public string ParamterTitle { get; set; }
        public bool IsMandotory { get; set; }
        public short ParameterOrder { get; set; }
        public string RegexValidator { get; set; }
        public string RegexValidatorMessage { get; set; }
        public string Type { get; set; }

    }
}
