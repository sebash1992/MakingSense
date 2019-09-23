using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Definitions.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id", TenantId = "tenantId", UserRole = "userRole", SelectedTenant = "selectedTenant";
            }
            public static class UserRoles
            {
                public const string Administrator = "Administrador", Seller = "Vendedor";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }

            public static class States
            {
                public const string Active = "Activo", Deleted = "Borrado", Draft = "Draft", Private = "Privado";
            }
        }
    }
}