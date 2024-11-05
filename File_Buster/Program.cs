using System;
using System.IO;

namespace File_Buster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = "../markdown";
            string outputDirectory = "../html";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create an instance of the MarkdownParser
            Parser parser = new Parser();

            // Process each Markdown file in the input directory
            foreach (var filePath in Directory.GetFiles(inputDirectory, "*.md"))
            {
                string markdownContent = ReadMarkdownFile(filePath);
                
                // Convert markdown to HTML
                string htmlContent = parser.Parse(markdownContent);
                
                // Save the converted HTML
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string outputFilePath = Path.Combine(outputDirectory, $"{fileName}.html");
                File.WriteAllText(outputFilePath, htmlContent);

                Console.WriteLine($"Converted {filePath} to {outputFilePath}");
            }
        }

        static string ReadMarkdownFile(string markdownFilePath)
        {
            return File.ReadAllText(markdownFilePath);
        }
    }
}
