namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)// dung de khoi tao du lieu mau
        {
            //test danh sach san pham
            CreateProductCategorySample(context);

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Education"
            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)// dung de khoi tao du lieu mau
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory () { Name="danh muc 1", Alias="danh-muc-1", Status=true },
                new ProductCategory () { Name="danh muc 2", Alias="danh-muc-2", Status=true },
                new ProductCategory () { Name="danh muc 3", Alias="danh-muc-3", Status=true },
                new ProductCategory () { Name="danh muc 4", Alias="danh-muc-4", Status=true },
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
    }
}
