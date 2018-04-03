namespace SampleFormGenerator.DAL.Tools
{
    public static class PrepareWhereConditionExtention
    {
        public static string PrepareWhereCondition(this string value)
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                value = " 1=1 ";
            }
            return value;
        }
    }
}
