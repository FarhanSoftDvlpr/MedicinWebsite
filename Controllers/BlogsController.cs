using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("blogs")]
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs
                .Include(x => x.BlogCategory)
                .Where(x =>
                    x.IsActive == true &&
                    x.IsDeleted == false)
                .OrderByDescending(x => x.PublishedAt)
                .Select(x => new PublicBlogListViewModel
                {
                    Id = x.Id,
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    Slug = x.Slug,
                    ShortDescriptionEn = x.ShortDescriptionEn,
                    ShortDescriptionAr = x.ShortDescriptionAr,
                    ImagePath = x.ImagePath,
                    PublishedAt = x.PublishedAt,
                    CategoryNameEn = x.BlogCategory != null ? x.BlogCategory.NameEn : null,
                    CategoryNameAr = x.BlogCategory != null ? x.BlogCategory.NameAr : null
                })
                .ToListAsync();

            ViewData["Title"] = "Blogs";

            return View(blogs);
        }

        [HttpGet]
        [Route("blog/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Include(x => x.BlogCategory)
                .Where(x =>
                    x.Slug == slug &&
                    x.IsActive == true &&
                    x.IsDeleted == false)
                .Select(x => new PublicBlogDetailViewModel
                {
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    Slug = x.Slug,
                    ShortDescriptionEn = x.ShortDescriptionEn,
                    ShortDescriptionAr = x.ShortDescriptionAr,
                    DescriptionEn = x.DescriptionEn,
                    DescriptionAr = x.DescriptionAr,
                    ImagePath = x.ImagePath,
                    PublishedAt = x.PublishedAt,
                    CategoryNameEn = x.BlogCategory != null ? x.BlogCategory.NameEn : null,
                    CategoryNameAr = x.BlogCategory != null ? x.BlogCategory.NameAr : null,
                    MetaTitleEn = x.MetaTitleEn,
                    MetaDescriptionEn = x.MetaDescriptionEn
                })
                .FirstOrDefaultAsync();

            if (blog == null)
            {
                return NotFound();
            }

            ViewData["Title"] = !string.IsNullOrWhiteSpace(blog.MetaTitleEn)
                ? blog.MetaTitleEn
                : blog.TitleEn;

            ViewData["MetaDescription"] = blog.MetaDescriptionEn;

            return View(blog);
        }
    }
}