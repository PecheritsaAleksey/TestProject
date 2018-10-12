using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuotationManager.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City {Id = 1, Name = "Красноярск", SignificanceLevel = 10},
                new City {Id = 2, Name = "Новосибирск", SignificanceLevel = 8},
                new City {Id = 3, Name = "Москва", SignificanceLevel = 5},
                new City {Id = 4, Name = "Санкт-Петербург", SignificanceLevel = 6},
                new City {Id = 5, Name = "Челябинск", SignificanceLevel = 1});
            modelBuilder.Entity<Contribution>().HasData(
                new Contribution {Id = 1, Name = "Плохая экология", BaseSum = 10, CityId = 1},
                new Contribution {Id = 2, Name = "Плохие дороги", BaseSum = 10, CityId = 1},
                new Contribution {Id = 3, Name = "Нет метро", BaseSum = 3, CityId = 1},
                new Contribution {Id = 4, Name = "Столица Сибири", BaseSum = 5, CityId = 2},
                new Contribution {Id = 5, Name = "Красивый город", BaseSum = 8, CityId = 4},
                new Contribution {Id = 6, Name = "Столица России", BaseSum = 10, CityId = 3},
                new Contribution {Id = 7, Name = "Вечные пробки", BaseSum = 10, CityId = 3},
                new Contribution {Id = 8, Name = "Плохая экология", BaseSum = 7, CityId = 5});
            modelBuilder.Entity<Purpose>().HasData(
                new Purpose {Id = 1, Name = "Ипотека"},
                new Purpose {Id = 2, Name = "Потребительский кредит" }, 
                new Purpose {Id = 3, Name = "Автокредит" });
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<QuotaContribution> QuotaContributions { get; set; }
    }
}