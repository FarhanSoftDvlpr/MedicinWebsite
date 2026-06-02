namespace MEDICINE.WEB.ViewModels.Menus
{
    public class PublicMenuViewModel
    {
        public int Id { get; set; }

        public int? ParentMenuId { get; set; }

        public string TitleEn { get; set; }

        public string TitleAr { get; set; }

        public string Url { get; set; }

        public bool OpenInNewTab { get; set; }

        public List<PublicMenuViewModel> ChildMenus { get; set; } = new();
    }
}