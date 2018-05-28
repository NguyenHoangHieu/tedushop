using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity; //ke thua DbContext
using TeduShop.Model.Models;

namespace TeduShop.Data
{
    //bai 15 thay gi ke thua tu DbContext ta ke thua IdentityDbContext<ApplicationUser> de su dung Identiy Framwork
    //public class TeduShopDbContext : DbContext -- mac dinh
    public class TeduShopDbContext : IdentityDbContext<ApplicationUser> //cai Microsoft.AspNet.Identity.EntityFramework 
    {
        //b1 tao 2 thu muc infastructure
        //b2
        //khi tao tedushopdbcontext thi add 1 chuoi ket noi vao App.config
        // <connectionStrings>
        //   <clear/>
        //    <add name = "TeduShopConnection" connectionString="data source=.;initial catalog=TeduShop;user id=sa;password=456456; MultipleActiveResultSets=True" />
        //  </connectionStrings>

        public TeduShopDbContext() : base("TeduShopConnection") // khoi tao ham ket noi
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //b3
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        //dung de tạo log hệ thống
        public DbSet<Error> Errors { get; set; }

        //bai 15 - identity
        public static TeduShopDbContext Create()
        {
            return new TeduShopDbContext();
        }

        //b4 
        //tao hàm này để tạo entity framework
        //b5 vào tạo IDbFactory
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             //modelBuilder.Entity<IdentityUserRole>().HasKey(i =>  new { i.UserId, i.RoleId });//chỉ ra khóa chính
             //modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);//chỉ ra khóa chính
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }

       

    }
}