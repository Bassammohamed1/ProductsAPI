using Microsoft.AspNetCore.Identity;

namespace TestApi.NewFolder
{
    public static class AddRoleAndUser
    {
        public static async Task AddRole(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
        public static async Task AddUser(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser { UserName = "Admin", Email = "Admin@gmail.com", PhoneNumber = "123456789" };
            await userManager.CreateAsync(user, "Ba$$am3324");
            await userManager.AddToRoleAsync(user, "Admin");
            await userManager.AddToRoleAsync(user, "User");
        }
    }
}
