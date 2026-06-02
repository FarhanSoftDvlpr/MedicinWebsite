using Microsoft.AspNetCore.Mvc;

namespace MEDICINE.WEB.Filters
{
    public class PermissionAuthorizeAttribute
        : TypeFilterAttribute
    {
        public PermissionAuthorizeAttribute(
            string permission
        ) : base(typeof(PermissionAuthorizationFilter))
        {
            Arguments = new object[]
            {
                permission
            };
        }
    }
}