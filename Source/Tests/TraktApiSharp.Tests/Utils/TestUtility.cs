namespace TraktApiSharp.Tests.Utils
{
    using System.IO;
    using System.Reflection;
    using System.Text;

    public static class TestUtility
    {
        public static string GetDataFilePath(string filePath)
        {
            var execAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            return !string.IsNullOrEmpty(filePath) ? Path.Combine(execAssemblyLocation, "TestData", filePath) : string.Empty;
        }

        public static string ReadFileContents(string filePath)
        {
            var jsonFile = File.ReadAllText(GetDataFilePath(filePath), Encoding.UTF8);
            return !string.IsNullOrEmpty(jsonFile) ? jsonFile : string.Empty;
        }
    }
}
