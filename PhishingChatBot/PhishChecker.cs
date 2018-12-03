using System;
using System.IO;

namespace PhishingChatBot
{
    public static class PhishChecker
    {

        public static bool ValidateUrl(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        public static bool CheckUrl(string url)
        {
            string path = "Data/Phishtank.csv";
            var strLines = File.ReadLines(path);
            foreach (var line in strLines)
            {
                if (line.Split(',')[1].Equals(url))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
