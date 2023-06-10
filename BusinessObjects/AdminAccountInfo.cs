using BusinessObjects.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class AdminAccountInfo
    {
        static AdminAccountInfo()
        {
            IConfiguration configuration = FUFlowerBouquetManagementContext.GetConfiguration();
            Email = configuration["AdminAccount:Email"];
            Password = configuration["AdminAccount:Password"];
        }
        public static string Email { get; }
        public static string Password { get; }
    }
}
