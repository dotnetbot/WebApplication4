using Models;

namespace WebApplication4.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //var persons = new List<Person>();
            //persons.Add()

            context.RejectCauses.AddOrUpdate(s => s.Id,
                new RejectCause { Id = Guid.Parse("4cb9342d-4717-e611-aaf8-38607729f0cd"), Text = "Представленные заявителем документы не подтверждают отнесение гражданина к отдельным категориям граждан" },
                new RejectCause { Id = Guid.Parse("4db9342d-4717-e611-aaf8-38607729f0cd"), Text = "Представленные заявителем документы и заявление содержат противоречивые или недостоверные сведения" },
                new RejectCause { Id = Guid.Parse("4eb9342d-4717-e611-aaf8-38607729f0cd"), Text = "Заявителем представлен неполный комплект документов в соответствии пунктами 2.6 - 2.7 Порядка, утвержденного Правительством Республики Башкортостан" },
                new RejectCause { Id = Guid.Parse("4fb9342d-4717-e611-aaf8-38607729f0cd"), Text = "Заявление подано не уполномоченным лицом" },
                new RejectCause { Id = Guid.Parse("50b9342d-4717-e611-aaf8-38607729f0cd"), Text = "Гражданин включен в список граждан, формируемый в отношении другого объекта жилищного строительства некоммерческой организации" },
                new RejectCause { Id = Guid.Parse("51b9342d-4717-e611-aaf8-38607729f0cd"), Text = "Гражданин ранее улучшил жилищные условия в соответствии с Порядком, утвержденным Правительством Республики Башкортостан" }
                );

            context.ClaimStates.AddOrUpdate(s => s.Id,
                new State { Id = Guid.Parse("ec402ebb-9516-e611-aaf8-38607729f0cd"), Name = "Заявление зарегистрировано" },
                new State { Id = Guid.Parse("ed402ebb-9516-e611-aaf8-38607729f0cd"), Name = "Отказ" },
                new State { Id = Guid.Parse("ee402ebb-9516-e611-aaf8-38607729f0cd"), Name = "В работе" }
                );

            context.Buildings.AddOrUpdate(b => b.Id,
                new Building { Id = Guid.Parse("371054a1-5c13-e611-aaf8-38607729f0cd"), Title = "г.Уфа, Кузнецовский затон, литер 5" },
                new Building { Id = Guid.Parse("381054a1-5c13-e611-aaf8-38607729f0cd"), Title = "г.Уфа, Шакша, литер 10" },
                new Building { Id = Guid.Parse("391054a1-5c13-e611-aaf8-38607729f0cd"), Title = "г.Уфа, ул. Блюхера, литер 11" },
                new Building { Id = Guid.Parse("e9edd1e8-6316-e611-aaf8-38607729f0cd"), Title = "г.Уфа, Кузнецовский затон, литер 6" },
                new Building { Id = Guid.Parse("eaedd1e8-6316-e611-aaf8-38607729f0cd"), Title = "г.Уфа, Затон, литер 10" },
                new Building { Id = Guid.Parse("ebedd1e8-6316-e611-aaf8-38607729f0cd"), Title = "г.Уфа, ул. Геологов, литер 1" }
                );

            context.People.AddOrUpdate(
              p => p.Id,
              new Person
              {
                  Id = Guid.Parse("C5ADF561-2C0D-E611-AAF6-38607729F0CD"),
                  FirstName = "Регина",
                  LastName = "Сафина",
                  MiddleName = "Альфредовна",
                  DateOfBirth = new DateTime(1980, 5, 1),
                  Snils = "12762360554",
                  PassportSeries = "8004",
                  PassportNumber = "968326",
                  PassportDate = new DateTime(2006, 11, 5),
                  Claims = new List<ClaimData>() {
                      new ClaimData {
                          Id = Guid.Parse("C6ADF561-2C0D-E611-AAF6-38607729F0CD"),
                          Inn = "026808038707",
                          Job = "Железная дорога",
                          JobSphere = "Железнодорожная",
                          FamilyIncome = "27000",
                          Email = "zheleznodorozhnik@mail.ksadjf",
                          Ownership = "Дом",
                          PersonalIncome = "10000",
                          Phone = "9174032343",
                          Position = "Железнодорожник",
                          PostAddress = "г. Уфа",
                          RegAddress = "г. Уфа",
                          DateTime = new DateTime(2016, 5, 4, 12, 52, 0)
                      }
                  }
              },
              new Person { Id = Guid.Parse("C7ADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Оксана", LastName = "Желнова", MiddleName = "Юрьевна", DateOfBirth = new DateTime(1980, 5, 1), Snils = "12671109641", PassportSeries = "8001", PassportNumber = "344626", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("C8ADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Марс", LastName = "Ульмаскулов", MiddleName = "Маратович", DateOfBirth = new DateTime(1980, 5, 1), Snils = "11298005135", PassportSeries = "8001", PassportNumber = "344626", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("C9ADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Андрей", LastName = "Хайруллин", MiddleName = "Гизарович", DateOfBirth = new DateTime(1980, 5, 1), Snils = "12981379899", PassportSeries = "8004", PassportNumber = "854418", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CAADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Альбина", LastName = "Ишмухаметова", MiddleName = "Римовна", DateOfBirth = new DateTime(1980, 5, 1), Snils = "11077874054", PassportSeries = "8005", PassportNumber = "059518", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CBADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Алик", LastName = "Абзалилов", MiddleName = "Рифович", DateOfBirth = new DateTime(1980, 5, 1), Snils = "03072961031", PassportSeries = "8011", PassportNumber = "394265", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CCADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Римма", LastName = "Лаврушина", MiddleName = "Михайловна", DateOfBirth = new DateTime(1980, 5, 1), Snils = "07145845469", PassportSeries = "8007", PassportNumber = "429147", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CDADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Ингиль", LastName = "Хасанов", MiddleName = "Нилович", DateOfBirth = new DateTime(1980, 5, 1), Snils = "11504668029", PassportSeries = "8005", PassportNumber = "659443", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CEADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Регина", LastName = "Богданова", MiddleName = "Фанилевна", DateOfBirth = new DateTime(1980, 5, 1), Snils = "13560032723", PassportSeries = "8005", PassportNumber = "059187", PassportDate = new DateTime(2006, 11, 5) },
              new Person { Id = Guid.Parse("CFADF561-2C0D-E611-AAF6-38607729F0CD"), FirstName = "Рита", LastName = "Габбасова", MiddleName = "Нурулловна", DateOfBirth = new DateTime(1980, 5, 1), Snils = "11375149543", PassportSeries = "8008", PassportNumber = "564759", PassportDate = new DateTime(2006, 11, 5) }
            );            
        }
    }
}
