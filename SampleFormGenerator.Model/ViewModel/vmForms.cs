namespace SampleFormGenerator.Model.ViewModel
{
    public class vmForms
    {
        public vmForms(int id,string title)
        {
            FormId = id;

            FormTitle = title;
        }
        public int FormId { get; set; }
        public string FormTitle { get; set; }
    }
}
