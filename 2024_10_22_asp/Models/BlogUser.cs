using System.ComponentModel.DataAnnotations;

namespace _2024_10_22_asp.Models
{
    public class BlogUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
