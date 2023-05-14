using System.Xml.Linq;

namespace Zoo.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
