using IDENTITY_Cwiczenia.Identity.Model;
using IDENTITY_Cwiczenia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IDENTITY_Cwiczenia.Identity.DbContext
{
    public class AppIdentityContext : IdentityDbContext<User>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options) { }
    }
}
