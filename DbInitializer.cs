using ChocoLync.Models;
using Microsoft.EntityFrameworkCore;

namespace ChocoLync.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "Owner" },
                    new Role { Name = "Admin" },
                    new Role { Name = "Employee" },
                    new Role { Name = "Customer" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
                context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "123",
                    RoleId = adminRole.Id
                });
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Chocolate Bars" },
                    new Category { Name = "Boxed Chocolates" },
                    new Category { Name = "Truffles" },
                    new Category { Name = "Dark Chocolate" },
                    new Category { Name = "White Chocolate" },
                    new Category { Name = "Seasonal Specials" }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var cats = context.Categories.ToDictionary(c => c.Name, c => c.Id);

                context.Products.AddRange(
                    new Product { Name = "Milk Chocolate Bar", SKU = "CHO-001", Brand = "Cadbury", Unit = "pcs", CategoryId = cats["Chocolate Bars"], Price = 150, BuyingPrice = 90, StockQuantity = 100, AlertQuantity = 10, Description = "Classic milk chocolate bar 100g" },
                    new Product { Name = "Dark Chocolate Bar 70%", SKU = "CHO-002", Brand = "Lindt", Unit = "pcs", CategoryId = cats["Dark Chocolate"], Price = 250, BuyingPrice = 160, StockQuantity = 80, AlertQuantity = 10, Description = "Rich dark chocolate with 70% cocoa" },
                    new Product { Name = "White Chocolate Bar", SKU = "CHO-003", Brand = "Milka", Unit = "pcs", CategoryId = cats["White Chocolate"], Price = 180, BuyingPrice = 110, StockQuantity = 60, AlertQuantity = 10, Description = "Creamy white chocolate bar 100g" },
                    new Product { Name = "Assorted Truffles Box", SKU = "CHO-004", Brand = "Ferrero", Unit = "box", CategoryId = cats["Truffles"], Price = 650, BuyingPrice = 400, StockQuantity = 40, AlertQuantity = 5, Description = "12-piece assorted chocolate truffles" },
                    new Product { Name = "Premium Chocolate Gift Box", SKU = "CHO-005", Brand = "Godiva", Unit = "box", CategoryId = cats["Boxed Chocolates"], Price = 1500, BuyingPrice = 950, StockQuantity = 25, AlertQuantity = 5, Description = "Luxury 24-piece chocolate gift box" },
                    new Product { Name = "Almond Chocolate Bar", SKU = "CHO-006", Brand = "Cadbury", Unit = "pcs", CategoryId = cats["Chocolate Bars"], Price = 200, BuyingPrice = 130, StockQuantity = 90, AlertQuantity = 10, Description = "Milk chocolate with whole almonds" },
                    new Product { Name = "Hazelnut Spread Chocolate", SKU = "CHO-007", Brand = "Nutella", Unit = "pcs", Weight = 0.4m, CategoryId = cats["Chocolate Bars"], Price = 350, BuyingPrice = 220, StockQuantity = 50, AlertQuantity = 8, Description = "Creamy hazelnut chocolate spread 400g" },
                    new Product { Name = "Easter Egg Special", SKU = "CHO-008", Brand = "Cadbury", Unit = "pcs", CategoryId = cats["Seasonal Specials"], Price = 450, BuyingPrice = 280, StockQuantity = 30, AlertQuantity = 5, Description = "Large milk chocolate Easter egg" },
                    new Product { Name = "Dark Chocolate Almonds", SKU = "CHO-009", Brand = "Lindt", Unit = "pack", CategoryId = cats["Dark Chocolate"], Price = 320, BuyingPrice = 200, StockQuantity = 45, AlertQuantity = 8, Description = "Dark chocolate covered almonds 200g" },
                    new Product { Name = "Chocolate Wafer Bar", SKU = "CHO-010", Brand = "KitKat", Unit = "pcs", CategoryId = cats["Chocolate Bars"], Price = 80, BuyingPrice = 45, StockQuantity = 200, AlertQuantity = 20, Description = "Crisp wafer covered in milk chocolate" },
                    new Product { Name = "Mini Chocolate Assortment", SKU = "CHO-011", Brand = "Ferrero", Unit = "pack", CategoryId = cats["Boxed Chocolates"], Price = 500, BuyingPrice = 320, StockQuantity = 35, AlertQuantity = 5, Description = "Mixed mini chocolate pack 300g" },
                    new Product { Name = "Caramel Chocolate Bar", SKU = "CHO-012", Brand = "Milka", Unit = "pcs", CategoryId = cats["Chocolate Bars"], Price = 170, BuyingPrice = 100, StockQuantity = 75, AlertQuantity = 10, Description = "Milk chocolate with caramel filling" },
                    new Product { Name = "White Chocolate Macadamia", SKU = "CHO-013", Brand = "Lindt", Unit = "pcs", CategoryId = cats["White Chocolate"], Price = 280, BuyingPrice = 180, StockQuantity = 40, AlertQuantity = 8, Description = "White chocolate with macadamia nuts" },
                    new Product { Name = "Chocolate Lava Cake Mix", SKU = "CHO-014", Brand = "Ghirardelli", Unit = "box", CategoryId = cats["Seasonal Specials"], Price = 400, BuyingPrice = 250, StockQuantity = 20, AlertQuantity = 5, Description = "Premium chocolate lava cake mix" },
                    new Product { Name = "Dark Chocolate Mint", SKU = "CHO-015", Brand = "After Eight", Unit = "pack", CategoryId = cats["Dark Chocolate"], Price = 220, BuyingPrice = 140, StockQuantity = 55, AlertQuantity = 8, Description = "Dark chocolate with mint filling 200g" }
                );
                context.SaveChanges();
            }
        }
    }
}
