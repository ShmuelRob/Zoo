using System.Text.Json.Serialization;

namespace Zoo.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public string? Visitor { get; set; }
        public int AnimalId { get; set; }
        [JsonIgnore]
        public Animal? AnimalCommented { get; set; }
    }
}
