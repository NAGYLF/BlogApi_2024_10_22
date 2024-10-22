using Microsoft.AspNetCore.Mvc;
using _2024_10_22_asp.Models;
using static _2024_10_22_asp.Models.Dto;

namespace _2024_10_22_asp.Controllers
{
    [Route("BlogUser")]
    [ApiController]
    public class BlogUserController : ControllerBase
    {
     
     
            [HttpGet]
            public ActionResult<List<BlogUser>> Get()
            {
                using (var context = new BlogUserDbContext())
                {
                    return StatusCode(201, context.NewBlogUser.ToList());
                }
            }

            [HttpGet("{id}")]
            public ActionResult<BlogUser> GetById(Guid id)
            {
                using (var context = new BlogUserDbContext())
                {
                    return StatusCode(200, context.NewBlogUser.FirstOrDefault(x => x.Id == id));
                }
            }

            [HttpPost]
            public ActionResult<BlogUser> Post(CreateBlogUserDto createBlogUserDto)
            {
                var BlogUser = new BlogUser
                {
                    Id = Guid.NewGuid(),
                    Title = createBlogUserDto.Title,
                    Description = createBlogUserDto.Description,
                    CreatedTime = createBlogUserDto.CretedTime,
                    LastUpdate = createBlogUserDto.LastUpdate,
                };

                using (var context = new BlogUserDbContext())
                {
                    context.NewBlogUser.Add(BlogUser);
                    context.SaveChanges();

                    return StatusCode(201, BlogUser);
                }
            }
        
            [HttpPut("{id}")]
            public ActionResult<BlogUser> Put(Guid id, UpdateBlogUserDto updateBlogUserDto)
            {
                using (var context = new BlogUserDbContext())
                {
                    var existingBlogUser = context.NewBlogUser.FirstOrDefault(x => x.Id == id);

                existingBlogUser.Description = updateBlogUserDto.Description;
                existingBlogUser.Title = updateBlogUserDto.Title;
                existingBlogUser.CreatedTime = updateBlogUserDto.CretedTime;
                existingBlogUser.LastUpdate = updateBlogUserDto.LastUpdate;
               

                    context.NewBlogUser.Update(existingBlogUser);
                    context.SaveChanges();

                    return StatusCode(200, existingBlogUser);
                }
            }

            [HttpDelete]
            public ActionResult<object> Delete(Guid id)
            {
                using (var context = new BlogUserDbContext())
                {
                    var BlogUser = context.NewBlogUser.FirstOrDefault(x => x.Id == id);

                    if (BlogUser != null)
                    {
                        context.NewBlogUser.Remove(BlogUser);
                        context.SaveChanges();
                        return StatusCode(200, new { message = "Sikeres törlés!" });
                    }

                }
                return StatusCode(404, new { message = "Nincs ilyen felhasználó!" });
            }
        
    }
}
