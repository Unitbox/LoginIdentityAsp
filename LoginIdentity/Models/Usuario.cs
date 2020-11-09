using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace LoginIdentity.Models
{
    public class Usuario 
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }


    }

    public static class CustomClaimTypes
    {
        public const string idUsuario = "id_usuario";
    }

    public static class IdentityExtensions
    {
        public static int GetSalesId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.idUsuario);

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static string GetPostalCode(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.PostalCode);

            return claim?.Value ?? string.Empty;
        }
    }
}