namespace Zoo.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string? Content { get; set; }
        public string? Visitor { get; set; }
        public int AnimalID { get; set; }
        public Animal? AnimalCommented { get; set; }
    }
}
