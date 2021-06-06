using System.Collections.Generic;

namespace EasyDoc.Application.Models
{
    public class CommentOutput
    {
        public CommentOutput()
        {
            PropertyComments = new Dictionary<string, string>();
            ConstructorComments = new Dictionary<string, string>();
            MethodComments = new Dictionary<string, string>();
        }

        public string Name { get; set; }
        public string TopLevelComment { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<string> Sees { get; set; }

        public Dictionary<string, string> PropertyComments { get; set; }
        public Dictionary<string, string> ConstructorComments { get; set; }
        public Dictionary<string, string> MethodComments { get; set; }
    }
}
