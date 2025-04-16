namespace ProgrammingTesting.Extensions
{
    public static class StringExtensions
    {
        public static Int32 ToInt32(this String str)
        {
            return Int32.Parse(str.ToString());
        }

        public static String? GetSubstringAfter(this String str, String beginScipStr)
        {
            if(str.StartsWith(beginScipStr))
                return str.Substring(beginScipStr.Length);
            else return null;      
        }
    }
}
