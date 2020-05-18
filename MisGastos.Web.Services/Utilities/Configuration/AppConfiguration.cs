using MisGastos.Domain.Model.Authorization;
using System;
using System.Collections.Generic;

namespace MisGastos.Web.Services.Utilities.Configuration
{
    public static class AppConfiguration
    {
        public const  string GeneralAccessPolicyName = "GeneralAccess";
        public static string ImagesPath { get; set; }
        public static bool Application_ManageActionValidations { get; set; }
        public static bool Application_ManageSpecialActionValidations { get; set; }
        public static double TokenExpiration { get; set; }
        public static string TokenSecretKey { get; set; }
        public static string TokenAlgorithm { get; set; }
        public static string TokenAudiencie { get; set; }
        public static string TokenIssuer { get; set; }
        public static bool Token_ValidateIssuer { get; set; }
        public static bool Token_ValidateAudience { get; set; }
        public static bool Token_ValidateLifetime { get; set; }
        public static bool Token_ValidateIssuerSigningKey { get; set; }
        public static IEnumerable<RoleControlViewModel> RoleControls { get; set; }
    }
}
