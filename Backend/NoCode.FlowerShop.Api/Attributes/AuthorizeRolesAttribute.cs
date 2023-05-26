using Microsoft.AspNetCore.Authorization;
using NoCode.FlowerShop.Domain.Common;

namespace NoCode.FlowerShop.Api.Attributes;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params UserRole[] roles) : base()
    {
        Roles = string.Join(',', roles);
    }
}
