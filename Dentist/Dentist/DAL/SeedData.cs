using Dentist.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Slugify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.DAL
{
    public class SeedData
    {
        static public void Initital(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                InitialBio(db);
                InitialBlog(db);
                InitialDoctor(db);
                InitialPatient(db);
                InitialPortfolio(db);
                InitialSlider(db);
                InitialTreatment(db);
                InitialWellComing(db);
            }
        }

        private static void InitialWellComing(AppDbContext db)
        {
            if (!db.WellComings.Any())
            {
                db.WellComings.Add(new WellComing
                {
                    Description = "Рядом с ними протекает небольшая речка Дуден, снабжающая его необходимыми регелиалами. Это райская страна, в которой жареные части предложений летят вам в рот. Даже всемогущий Пойнтинг не контролирует слепые тексты, это почти неортографическая жизнь. Однажды небольшая строчка слепого текста по имени Lorem Ipsum решила уйти в далекий Мир грамматики.",
                    Image= "back1.png",
                    WelcomeTitle= "Медицинская специальность по уходу за тяжелобольными госпитализированными пациентами"
                });
                db.SaveChanges();
            }
        }

        private static void InitialTreatment(AppDbContext db)
        {
            if (!db.Treatments.Any())
            {
                db.Add(new Treatment
                {
                    About = "Даже всемогущий Пойнтинг не контролирует слепые тексты, это почти неортографический.",
                    TreatmentName = "Зубные Имплантаты",
                    Image = "kamranportfolio.png",

                });
                db.SaveChanges();
            }
        }

        private static void InitialSlider(AppDbContext db)
        {
            if (!db.Sliders.Any())
            {
                db.Sliders.Add(new Slider
                {
                    Image = "back1.png",
                    SliderTitle = "Улыбка производит неизгладимое впечатление",
                    SliderDescription = "Ваше здоровье - наш главный приоритет в доступной медицинской помощи.",

                });
                db.Sliders.Add(new Slider
                {
                    Image = "back2.png",
                    SliderTitle = "Улыбка производит неизгладимое впечатление",
                    SliderDescription = "Ваше здоровье - наш главный приоритет в доступной медицинской помощи.",

                });
                db.SaveChanges();
            }
        }

        private static void InitialPortfolio(AppDbContext db)
        {
            if (!db.Portfolios.Any())
            {
                db.Portfolios.Add(new Portfolio
                {
                    Image = "kamranportfolio.png"
                });
                db.SaveChanges();
            }
        }

        private static void InitialPatient(AppDbContext db)
        {
            if (!db.Patients.Any())
            {
                db.Patients.Add(new Patient
                {
                    Description = "Далеко-далеко, за словесными горами, вдали от стран Вокалия и Консонантия живут слепые тексты.",
                    FullName = "Рэки Хендерсон",
                    Image = "person_2.jpg",
                    Profession = "Студент",

                });
                db.SaveChanges();
            }
        }

        private static void InitialDoctor(AppDbContext db)
        {
            if (!db.Doctors.Any())
            {
                db.Doctors.Add(new Doctor
                {
                    About = "Я амбициозный трудоголик, но в остальном довольно простой человек.",
                    FullName = "Камран Бадалов",
                    Gmail = "#",
                    Facebook = "#",
                    Image = "kamran.png",
                    Instagram = "#",
                    Position = "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР И ОСНОВАТЕЛЬ".ToLower(),
                    Twitter = "#",
                    Profession = "Dentist"
                });
                db.SaveChanges();
            }
        }

        private static void InitialBlog(AppDbContext db)
        {

            if (!db.Blogs.Any())
            {
                db.Blogs.Add(new Blog
                {
                    Author = "Камран",
                    BlogName = "Первый-блог",
                    Date = DateTime.Now,
                    Description = "Первое объяснение моего первого блога",
                    Image = "back2.png",
                    Slug = "Первый-блог"
                });
                db.SaveChanges();
            }

        }

        private static void InitialBio(AppDbContext db)
        {
            if (!db.Bios.Any())
            {
                db.Add(new Bio
                {
                    Address = "Ул. Гвардейцев Широницев 84 (2 й этаж)",
                    Email = "ckdentkamran@gmail.com",
                    Facebook = "#",
                    Instagram = "https://www.instagram.com/ckdent_kharkov/",
                    PhoneNumber = "073 208 2244",
                    Twitter = "#",
                    WeekDaysOpenHour = new TimeSpan(08, 00, 00),
                    WeekdayCloseHour = new TimeSpan(20, 00, 00)
                });
                db.SaveChanges();
            }
        }


    }
}
