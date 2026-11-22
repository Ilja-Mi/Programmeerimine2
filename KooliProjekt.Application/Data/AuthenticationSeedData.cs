using System;
using System.Linq;
using KooliProjekt.Application.Authentication;
namespace KooliProjekt.Application.Data
{
    // Called only in Development. Existing passwords and roles are never reset.
    public static class AuthenticationSeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            Add(context, "jwt_admin", true, "Admin20!11");
            Add(context, "jwt_employee", false, "Employee20!11");
            context.SaveChanges();
        }
        private static void Add(ApplicationDbContext context, string username, bool isAdmin, string password)
        {
            var existing = context.Employees.SingleOrDefault(x => x.Username == username);
            if (existing != null)
            {
                if (existing.IsAdmin != isAdmin)
                    throw new InvalidOperationException("Demo username has a different role: " + username);
                return;
            }
            Employee user = isAdmin ? new Administrator() : new Employee();
            user.Name = isAdmin ? "JWT demo administrator" : "JWT demo employee";
            user.Username = username;
            user.IsAdmin = isAdmin;
            user.Password = PasswordHelper.Hash(password);
            context.Employees.Add(user);
        }
    }
}
