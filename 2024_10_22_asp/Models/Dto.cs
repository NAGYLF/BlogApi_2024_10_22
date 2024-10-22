namespace _2024_10_22_asp.Models
{
    public class Dto
    {
        public record CreateBlogUserDto(string Title,string Description,DateTime LastUpdate,DateTime CretedTime);
        public record UpdateBlogUserDto(string Title, string Description, DateTime LastUpdate, DateTime CretedTime);
    }
}
