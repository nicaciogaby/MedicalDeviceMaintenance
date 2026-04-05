using Microsoft.AspNetCore.Identity;

namespace MedicalDeviceMaintenance.Data
{
    public static class SeedRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Create roles
            string[] roles = { "Admin", "Technician", "Viewer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create default Admin user
            var adminEmail = "admin@medtracker.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create default Technician user
            var techEmail = "tech@medtracker.com";
            var techUser = await userManager.FindByEmailAsync(techEmail);
            if (techUser == null)
            {
                techUser = new IdentityUser
                {
                    UserName = techEmail,
                    Email = techEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(techUser, "Tech123!");
                await userManager.AddToRoleAsync(techUser, "Technician");
            }

            // Create default Viewer user
            var viewerEmail = "viewer@medtracker.com";
            var viewerUser = await userManager.FindByEmailAsync(viewerEmail);
            if (viewerUser == null)
            {
                viewerUser = new IdentityUser
                {
                    UserName = viewerEmail,
                    Email = viewerEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(viewerUser, "Viewer123!");
                await userManager.AddToRoleAsync(viewerUser, "Viewer");
            }
        }
    }
}