namespace MEDICINE.WEB.Models.Admin.Navigation
{
    public class AdminMenuItem
    {
        public string Title { get; set; }

        public string ArabicTitle { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public string PermissionKey { get; set; }

        public bool IsVisible { get; set; }

        public List<AdminMenuItem> Children { get; set; }

        public AdminMenuItem()
        {
            Children = new List<AdminMenuItem>();
        }
    }
}