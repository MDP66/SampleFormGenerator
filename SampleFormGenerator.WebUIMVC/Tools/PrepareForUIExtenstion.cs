namespace SampleFormGenerator.WebUIMVC.Tools
{
    public static class PrepareForUIExtenstion
    {
        public static string PrepareForUI(this string value)
        {
            var forbidenChars = new string[] { " ", "&", "#", "$", "%", ":", "/", "\\", "*" };
            foreach (var item in forbidenChars)
            {
                value = value.Replace(item, "-");
            }
            return value;
        }
    }
}