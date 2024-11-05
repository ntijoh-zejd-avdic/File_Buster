using System;

namespace File_Buster
{
    public class Parser
    {
        public string Parse(string markdownContent)
        {
            string[] lines = markdownContent.Split('\n');
            string htmlContent = "";

            foreach (var line in lines)
            {
                if (line.StartsWith("# "))
                {
                    htmlContent += $"<h1>{line.Substring(2)}</h1>\n";
                }
                else if (line.StartsWith("## "))
                {
                    htmlContent += $"<h2>{line.Substring(3)}</h2>\n";
                }
                else if (line.StartsWith("### "))
                {
                    htmlContent += $"<h3>{line.Substring(4)}</h3>\n";
                }
                else
                {
                    // Basic replacements for bold and italic
                    string formattedLine = line.Replace("**", "<b>").Replace("**", "</b>");
                    formattedLine = formattedLine.Replace("*", "<i>").Replace("*", "</i>");
                    htmlContent += $"<p>{formattedLine}</p>\n";
                }
            }

            return htmlContent;
        }
    }
}
