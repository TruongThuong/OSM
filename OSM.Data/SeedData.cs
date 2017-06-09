using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSM.Model.Entities;

namespace OSM.Data
{
    public class SeedData
    {
        public static void Initialize(AppsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.ProductCategories.Any())
            {
                return;   // DB has been seeded
            }

            var listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true, CreatedDate=DateTime.Now },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=false, CreatedDate=DateTime.Now },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true, CreatedDate=DateTime.Now },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true, CreatedDate=DateTime.Now },
                    new ProductCategory() { Name="Nội thất",Alias="noi-that",Status=false, CreatedDate=DateTime.Now },
                     new ProductCategory() { Name="Văn phòng phẩm",Alias="van-phong-pham",Status=true, CreatedDate=DateTime.Now }
            };

            var listProduct = new List<Product>()
            {
                new Product() { Name="Điện lạnh",Alias="dien-lanh",Status=true,OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now },
                 new Product() { Name="Viễn thông",Alias="vien-thong",Status=false,OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now },
                  new Product() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true,OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now },
                   new Product() { Name="Mỹ phẩm",Alias="my-pham",Status=true, OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now },
                    new Product() { Name="Nội thất",Alias="noi-that",Status=false,OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now },
                      new Product() { Name="Thức ăn nhanh",Alias="thuc-an-nhanh",Status=true,OriginalPrice=1000,Price=2000,CategoryID=1, Quantity=10, CreatedDate=DateTime.Now },
                        new Product() { Name="Văn phòng phẩm",Alias="van-phong-pham",Status=true, OriginalPrice=1000,Price=2000,CategoryID=1,Quantity=10, CreatedDate=DateTime.Now }
            };
            context.Products.AddRange(listProduct);

            context.ProductCategories.AddRange(listProductCategory);
            context.SaveChanges();
        }
    }
}
