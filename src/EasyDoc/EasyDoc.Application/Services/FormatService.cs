using EasyDoc.Application.Interfaces;
using EasyDoc.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace EasyDoc.Application.Services
{
    public class FormatService : IFormatService
    {
        private readonly string[] formats = { "json" };

        public string? FormatAs(CommentOutput content, string format)
        {
            if (!FormatIsAvailable(format))
            {
                PrintErrorMessage(format);
                return null;
            }

            if (content == null)
            {
                return null;
            }

            string output = "";

            if (format == formats[0])
            {
                output = JsonSerializer.Serialize(content, new JsonSerializerOptions() { WriteIndented = true });
            }

            return output;
        }

        public string? FormatAs(List<CommentOutput> content, string format)
        {
            if (!FormatIsAvailable(format))
            {
                PrintErrorMessage(format);
                return null;
            }

            if (content == null)
            {
                return null;
            }

            string output = "";

            if (format == formats[0])
            {
                output = JsonSerializer.Serialize(content, new JsonSerializerOptions() { WriteIndented = true });
            }

            return output;
        }

        private bool FormatIsAvailable(string format)
        {
            return formats.Contains(format);
        }

        private void PrintErrorMessage(string format)
        {
            Console.WriteLine("The export format {0} is not known. Please choose one of these valid formats", format);
            foreach (var option in formats)
            {
                Console.Write("[{0}] ", option);
            }
        }
    }
}
