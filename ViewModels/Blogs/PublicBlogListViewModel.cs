namespace MEDICINE.WEB.ViewModels.Blogs
{
    public class PublicBlogListViewModel
    {
        public int Id { get; set; }

        public string TitleEn { get; set; }

        public string TitleAr { get; set; }

        public string Slug { get; set; }

        public string? ShortDescriptionEn { get; set; }

        public string? ShortDescriptionAr { get; set; }

        public string? ImagePath { get; set; }

        public DateTime PublishedAt { get; set; }

        public string? CategoryNameEn { get; set; }

        public string? CategoryNameAr { get; set; }
    }
}