using System;

namespace LINQPrac
{
    public static class ExtentionMethod
    {
        public static int ExtensionHelper(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                return str.Split(' ').Length;
            }

            return 0;
        }

        public static void GetWordCount()
        {
            string sentence = "ANTI-ASIAN HATE CRIMES HAVE INCREASED BY 1,900% (Source NYPD Data, 2020)";
            int wordCount = ExtensionHelper(sentence);
            Console.WriteLine(sentence);
            Console.WriteLine($"Word Count: {wordCount}");
        }   
        
    }
}