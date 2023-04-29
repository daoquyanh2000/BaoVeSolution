using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Base;
using BaoVeSolution.WebApplication.DB.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BaoVeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BaoVeContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            base.Seed(context);
            context.Users.AddOrUpdate(new User() { State = State.Active, Email = "123@gmail.com", Id = 1, Password = "123456", PhoneNumber = "123456789", UserName = "admin", IsAdmin = true });
            var layout = new Layout()
            {
                Id = 1,
                Address = "Số 1 hai bà trưng",
                PhoneNumber = "0987654321",
                Email = "123@gmail.com",
                Description = @"Lorem ipsum dolor sit amet,
                consectetur adipiscing elit, sed do eiusmod tempor incididunt ut l
                abore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat
                ",
                OpenTime = "Tất cả các ngày",
                CloseTime = "Trừ thứ 7 và cn",
                ApplicationName = "KHÁNH TOÀN"
            };
            var home = new HomePage()
            {
                YearsExperience = 20,
                Project = 33,
                Award = 83,
                Employees = 123,    
            };
            context.Layouts.AddOrUpdate(layout);
            context.HomePages.AddOrUpdate(home);
            context.SaveChanges();
            context.Categories.AddOrUpdate(
                new Category
                {
                    Id = 1,
                    Name = "Giới thiệu",
                    Slug = "gioi-thieu",
                    ParentId = 0,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 2,
                    Name = "Đối tác Đất Việt",
                    Slug = "doi-tac-dat-viet",
                    ParentId = 1,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 3,
                    Name = "Hồ sơ năng lực",
                    Slug = "ho-so-nang-luc",
                    ParentId = 1,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 4,
                    Name = "Danh bạ bảo vệ",
                    Slug = "danh-ba-bao-ve",
                    ParentId = 1,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 5,
                    Name = "Tin tức",
                    Slug = "tin-tuc",
                    ParentId = 0,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 6,
                    Name = "Tin Khánh Toàn",
                    Slug = "tin-khanh-toan",
                    ParentId = 5,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 7,
                    Name = "Tin tổng hợp",
                    Slug = "tin-tong-hop",
                    ParentId = 5,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 8,
                    Name = "Dịch vụ",
                    Slug = "dich-vu",
                    ParentId = 0,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 9,
                    Name = "Dịch vụ bảo vệ",
                    Slug = "dich-vu-bao-ve",
                    ParentId = 8,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 10,
                    Name = "Lắp đặt camera quan sát",
                    Slug = "lap-dat-camera-quan-sat",
                    ParentId = 8,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 11,
                    Name = "Lắp đặt bãi xe thông minh",
                    Slug = "lap-dat-bai-xe-thong-minh",
                    ParentId = 8,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 12,
                    Name = "Tuyển dụng bảo vệ",
                    Slug = "tuyen-dung-bao-ve",
                    ParentId = 13,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                },
                new Category
                {
                    Id = 14,
                    Name = "Tuyển dụng",
                    Slug = "tuyen-dung",
                    ParentId = 0,
                    CategoryState = CategoryState.Active, UserCreateId = 1,
                    Description = "Cập nhật các thông tin mới nhất về các sự kiện, chia sẻ trải nghiệm về chuyện nghề"
                });
            context.SaveChanges();
        }
    }
}