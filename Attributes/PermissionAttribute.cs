using MEDICINE.WEB.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MEDICINE.WEB.Attributes
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(string permission)
            : base(typeof(PermissionAuthorizationFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}