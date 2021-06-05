using EasyDoc.Application.Interfaces;
using EasyDoc.Application.Models;
using EasyDoc.Application.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace EasyDoc.Application.Services
{
    public class DocumentationService : IDocumentationService
    {
        private Rules.Rules selectedRule;
        private string[] knownExportFormats = { "json" };

        private List<Rules.Rules> rules = new List<Rules.Rules>()
        {
            new JavaRules()
        };

        public string CreateDocumentation(InputFile inputFile, string outputFormat)
        {
            selectedRule = rules.FirstOrDefault(r => r.FileExtension == inputFile.Extension);
            if (selectedRule == null)
            {
                Console.WriteLine("The format " + inputFile.Extension + " does not exist");
                return null;
            }

            if (inputFile.Extension == ".java")
            {
                string content = DocumentJava(inputFile, "xml");
                if (content != null)
                {
                    Console.WriteLine(content);
                }
            }

            return "";
        }

        private string DocumentJava(InputFile inputFile, string exportFormat)
        {
            if (!knownExportFormats.Contains(exportFormat))
            {
                Console.WriteLine("The export format {0} is not known. Please choose one of these valid formats", exportFormat);
                foreach(var format in knownExportFormats)
                {
                    Console.Write("[{0}] ", format);
                }
                return null;
            }

            var commentOutput = new CommentOutput();
            var content = inputFile.Content.ToCharArray();
            bool isComment = false;
            StringBuilder sb = new StringBuilder();

            int commentCounter = 0;
            for (int i = 0; i<content.Length; i++)
            {
                try
                {
                    if (isComment)
                    {
                        if (content[i] == '*' && content[i + 1] == '/')
                        {
                            isComment = false;
                            i += 2;

                            if (commentCounter == 1)
                            {
                                commentOutput.TopLevelComment = sb.ToString().Trim();
                                continue;
                            }

                            // Check what kind of comment was used
                            StringBuilder typeStringBuilder = new StringBuilder();
                            int j = i;
                           
                            while(content[j] != '{' && content[j] != ';')
                            {
                                typeStringBuilder.Append(content[j]);
                                j++;
                            }
                            string lineOutput = typeStringBuilder.ToString().Trim();
                            // Must be either Constructor or Method in java
                            if (lineOutput.Contains('(') || lineOutput.Contains(')'))
                            {
                                // Constructor
                                if (lineOutput.Contains(inputFile.Name))
                                {
                                    commentOutput.ConstructorComments.Add(lineOutput, sb.ToString().Trim());
                                }
                                // Method
                                else
                                {
                                    commentOutput.MethodComments.Add(lineOutput, sb.ToString().Trim());
                                }
                            } 
                            else
                            {
                                // Property
                                commentOutput.PropertyComments.Add(lineOutput, sb.ToString().Trim());
                            }

                            continue;
                        }
                        sb.Append(content[i]);
                    }

                    if (content[i] == '/' && content[i + 1] == '*' && content[i + 2] == '*' && !isComment)
                    {
                        sb = new StringBuilder();
                        i += 2;
                        isComment = true;
                        commentCounter++;
                    }

                }
                catch(IndexOutOfRangeException e)
                {

                }
            }
            return JsonSerializer.Serialize(commentOutput);
        }
    }
}
