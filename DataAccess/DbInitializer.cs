using System;
using DataAccess.Context;
using System.Linq;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class DbInitializer
    {
        public static async void Initialize(DocsDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Departament.Any())
            {
                var deps = new Departament[]
                {
                    new Departament() {Name = "IT"},
                    new Departament() {Name = "Managers"},
                    new Departament() {Name = "Lawyers"}
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
                        Departament = context.Departament.FirstOrDefault(c=>c.Id == 1)
                    },
                    new Employee()
                    {
                        Name = "Денисюк Анастасія",
                        FirstName = "Анастасія",
                        SecondName = "Денисюк",
                        Departament = context.Departament.FirstOrDefault(c=>c.Id == 1)
                    },
                    new Employee()
                    {
                        Name = "ІГ",
                        FirstName = "І",
                        SecondName = "Г",
                        Departament = context.Departament.FirstOrDefault(c=>c.Id == 3)
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
        }
    }
}