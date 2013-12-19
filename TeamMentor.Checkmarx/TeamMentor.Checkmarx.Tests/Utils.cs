using System;
using System.IO;

namespace TeamMentor.Checkmarx.Tests
{
    public static class Utils
    {
        #region Methods
        public static  string GetXmlResponseFromFile(string resourceName)
        {
            var result = String.Empty;
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                        result = reader.ReadToEnd();
                }
                else return "";
            }
            return result;
        }
        #endregion
    }
}
