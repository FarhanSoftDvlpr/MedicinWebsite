using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.Footer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FooterViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await _context.FooterSettings
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync();

            if (footer == null)
            {
                return View(new FooterViewModel());
            }

            var model = new FooterViewModel
            {
                CompanyNameEn = footer.CompanyNameEn,
                AboutTextEn = footer.AboutTextEn,
                AddressEn = footer.AddressEn,
                PhoneNumber = footer.PhoneNumber,
                WhatsAppNumber = footer.WhatsAppNumber,
                Email = footer.Email,
                FacebookUrl = footer.FacebookUrl,
                InstagramUrl = footer.InstagramUrl,
                YouTubeUrl = footer.YouTubeUrl,
                LinkedInUrl = footer.LinkedInUrl,
                TwitterUrl = footer.TwitterUrl,
                CopyrightTextEn = footer.CopyrightTextEn
            };

            return View(model);
        }
    }
}