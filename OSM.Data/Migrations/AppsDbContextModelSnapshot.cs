using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OSM.Data;

namespace OSM.Data.Migrations
{
    [DbContext(typeof(AppsDbContext))]
    partial class AppsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OSM.Model.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("BirthDay");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasMaxLength(250);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OSM.Model.Entities.ContactDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat");

                    b.Property<double?>("Lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Other");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("OSM.Model.Entities.Error", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("ID");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("OSM.Model.Entities.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Message")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("OSM.Model.Entities.Footer", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("OSM.Model.Entities.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DisplayOrder");

                    b.Property<int>("GroupID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Target")
                        .HasMaxLength(10);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("OSM.Model.Entities.MenuGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("MenuGroups");
                });

            modelBuilder.Entity("OSM.Model.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerId");

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(250);

                    b.Property<string>("PaymentStatus");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OSM.Model.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("OSM.Model.Entities.Page", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("OSM.Model.Entities.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("OSM.Model.Entities.PostCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("OSM.Model.Entities.PostTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("PostID");

                    b.HasKey("TagID", "PostID");

                    b.HasAlternateKey("PostID", "TagID");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("OSM.Model.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("MoreImages")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("OriginalPrice");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PromotionPrice");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Status");

                    b.Property<string>("Tags");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.Property<int?>("Warranty");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OSM.Model.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<bool>("isDeleted");

                    b.HasKey("ID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("OSM.Model.Entities.ProductTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("ProductID");

                    b.HasKey("TagID", "ProductID");

                    b.HasAlternateKey("ProductID", "TagID");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("OSM.Model.Entities.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("OSM.Model.Entities.SupportOnline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department")
                        .HasMaxLength(50);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("Mobile")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Skype")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Yahoo")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SupportOnlines");
                });

            modelBuilder.Entity("OSM.Model.Entities.SystemConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ValueInt");

                    b.Property<string>("ValueString")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("OSM.Model.Entities.Tag", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("OSM.Model.Entities.VisitorStatistic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50);

                    b.Property<DateTime>("VisitedDate");

                    b.HasKey("ID");

                    b.ToTable("VisitorStatistics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OSM.Model.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OSM.Model.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("OSM.Model.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OSM.Model.Entities.Menu", b =>
                {
                    b.HasOne("OSM.Model.Entities.MenuGroup", "MenuGroup")
                        .WithMany("Menus")
                        .HasForeignKey("GroupID");
                });

            modelBuilder.Entity("OSM.Model.Entities.Order", b =>
                {
                    b.HasOne("OSM.Model.Entities.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("OSM.Model.Entities.OrderDetail", b =>
                {
                    b.HasOne("OSM.Model.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID");

                    b.HasOne("OSM.Model.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("OSM.Model.Entities.Post", b =>
                {
                    b.HasOne("OSM.Model.Entities.PostCategory", "PostCategories")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("OSM.Model.Entities.PostTag", b =>
                {
                    b.HasOne("OSM.Model.Entities.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostID");

                    b.HasOne("OSM.Model.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });

            modelBuilder.Entity("OSM.Model.Entities.Product", b =>
                {
                    b.HasOne("OSM.Model.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("OSM.Model.Entities.ProductTag", b =>
                {
                    b.HasOne("OSM.Model.Entities.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductID");

                    b.HasOne("OSM.Model.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });
        }
    }
}
