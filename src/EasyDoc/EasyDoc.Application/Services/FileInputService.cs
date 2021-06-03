#nullable enable
using EasyDoc.Application.Interfaces;
using EasyDoc.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyDoc.Application.Services
{
    public class FileInputService : IFileInputService
    {
        /// <summary>
        /// If no filepaths are provided the tool grabs files,
        /// from the current directory
        /// </summary>
        /// <param name="filePaths">Paths to Files that need to be documented</param>
        /// <returns></returns>
        public List<string[]> GetFilePaths(List<string>? folderPaths)
        {
            var folders = new List<string[]>();
            if (folderPaths == null)
            {
                folders.Add(Directory.GetFiles(Directory.GetCurrentDirectory()));
            } 
            else
            {
                foreach(var folderPath in folderPaths)
                {
                    folders.Add(Directory.GetFiles(@"" + folderPath));
                }
            }

            Console.WriteLine("Documents the following Files");
            foreach(var folder in folders)
            {
                foreach(var filepath in folder)
                {
                    Console.WriteLine(filepath);
                }
            }

            return folders;
        }

        public List<InputFile> ReadFiles(List<string[]> folders)
        {
            Console.WriteLine("Reading Files");
            var output = new List<InputFile>();
            foreach (var folder in folders)
            {
                foreach (var filepath in folder)
                {
                    var inputFile = new InputFile();
                    inputFile.Path = filepath;
  
                    byte[] contents = File.ReadAllBytes(filepath);

                    var stringBuilder = new StringBuilder();
                    foreach (var c in contents)
                    {
                        stringBuilder.Append((char)c);
                    }

                    inputFile.Content = stringBuilder.ToString();
                    output.Add(inputFile);
                }
            }
            return output;
        }
    }
}
