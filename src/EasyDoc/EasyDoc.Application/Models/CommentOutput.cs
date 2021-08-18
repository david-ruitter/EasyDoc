using System.Collections.Generic;

namespace EasyDoc.Application.Models
{
    public class CommentOutput
    {
        public CommentOutput()
        {
            PropertyComments = new List<Comment>();
            ConstructorComments = new List<Comment>();
            MethodComments = new List<Comment>();
        }

        public string Name { get; set; }
        public string TopLevelComment { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<string> Sees { get; set; }

        public IEnumerable<Comment> PropertyComments { get; set; }
        public IEnumerable<Comment> ConstructorComments { get; set; }
        public IEnumerable<Comment> MethodComments { get; set; }
    }
}
