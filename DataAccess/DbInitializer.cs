using System;
using DataAccess.Context;
using System.Linq;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    
    public class DbInitializer
    {
        public static void Initialize(DocsDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Departament.Any())
            {
                var deps = new Departament[]
                {
                    new Departament() {Name = "Відділ ІТ"},
                    new Departament() {Name = "Торговий"},
                    new Departament() {Name = "Юристи"}
                };
                foreach (var item in deps)
                {
                    context.Departament.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Employee.Any())
            {
                var employee = new Employee[]
                {
                    new Employee()
                    {
                        Name = "Максим Біловус",
                        FirstName = "Максим",
                        SecondName = "Біловус",
                        Departament = context.Departament.FirstOrDefault(c=>c.Name == "Відділ ІТ").Id
                    }
                };
                foreach (var item in employee)
                {
                    context.Employee.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Company.Any())
            {
                var companies = new Company[]
                {
                    new Company() {Name = "24 Карата"},
                    new Company() {Name = "Діадема"},
                    new Company() {Name = "Тіара"},
                    new Company() {Name = "Вінтелепорт"},
                    new Company() {Name = "Датагруп"},
                    new Company() {Name = "Укртелеком"}
                };
                foreach (var item in companies)
                {
                    context.Company.Add(item);
                }
                context.SaveChanges();
            }

            //var username = "maxy3d@gmail.com";
            //if (context.Users.Count(x => x.Email == username) == 0)
            //{
            //    var user = context.Users.FirstOrDefault(u => u.UserName == username);
            //    if (user == null)
            //    {
            //        var hashedPassword = new PasswordHasher<IdentityUser>().HashPassword(null, username);
            //        user = new IdentityUser()
            //        {
            //            UserName = username,
            //            Email = username,
            //            EmailConfirmed = true,
            //            LockoutEnabled = true,
            //            NormalizedEmail = username,
            //            NormalizedUserName = username,
            //            PasswordHash = hashedPassword
            //        };
            //        context.Users.Add(user);

            //    }
            //}
            //var roleAdmin = "Admin";
            //if (context.Roles.Count(x => x.Name == roleAdmin) == 0)
            //{
            //    var role = context.Roles.FirstOrDefault(u => u.Name == roleAdmin);
            //    if (role == null)
            //    {
            //        role = new IdentityRole()
            //        {
            //            Name = roleAdmin
            //        };
            //        context.Roles.Add(role);
            //    }
            //}
            //if (!context.UserRoles.Any())
            //{
            //    context.UserRoles.Add(new IdentityUserRole<string>()
            //    {
            //        UserId = context.Users.FirstOrDefault(u => u.UserName == username)?.Id,
            //        RoleId = context.Roles.FirstOrDefault(u => u.Name == roleAdmin)?.Id
            //    }
            //    );
            //}
        }
    }
}
