using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TheBookieJoint.Models {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                            Name = "Тошнота", 
                            Author = "Жан Поль Сартр",
                            Translators = "Ю.Я. Яхнина",
                            Description = "Тошнота - это суть бытия людей, застрявших \"в сутолоке дня\". Людей - брошенных на милость чуждой, безжалостной, безотрадной реальности.</br>Тошнота - это невозможность любви и доверия, это - попросту - неумение мужчины и женщины понять друг друга.</br>Тошнота - это та самая \"другая сторона отчаяния\", по которую лежит Свобода.</br>Но - что делать с этой проклятой свободой человеку, осатаневшему от одиночества?",
                            OriginalLanguage = "Французский",
                            Language = "Русский",
                            ISBN = "978-5-17-082803-6",
                            Genre = "Классическая проза",
                            Publisher = "АСТ",
                            PublicationYear = "2015",
                            Price = 19 
                        },
                    new Product {
                            Name = "Смерть Демона", 
                            Author = "Рекс Стаут",
                            Translators = "С. Белов, А. Горский, Э. Михалева, А. Санин, Ю. Смирнов",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Русский",
                            ISBN = "978-5-699-21759-5",
                            Genre = "Детективный роман",
                            Publisher = "Эксмо",
                            PublicationYear = "2009", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Игра Престолов", 
                            Author = "Джордж Мартин",
                            Translators = "Ю.Р. Соколова",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Русский",
                            ISBN = "978-5-17-075250-8",
                            Genre = "Фантастический роман",
                            Publisher = "АСТ",
                            PublicationYear = "2012", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Психология Лжи", 
                            Author = "Пол Экман",
                            Translators = "Е. Бойко, Н. Исупова, Н. Мальгина, Н. Миронов, О. Терехова",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Русский",
                            ISBN = "978-5-459-00693-3",
                            Genre = "Популярная литература по психологии",
                            Publisher = "Питер",
                            PublicationYear = "2011", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Filth", 
                            Author = "Irvine Welsh",
                            Translators = "none",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Английский",
                            ISBN = "978-0-09-958383-7",
                            Genre = "Современная проза",
                            Publisher = "Vintage",
                            PublicationYear = "2013", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Темный Эльф", 
                            Author = "Роберт Сальваторе",
                            Translators = "А. Кострова, Е. Гуляева, В. Иванова",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Русский",
                            ISBN = "978-5-91377-053-0",
                            Genre = "Фантастический роман",
                            Publisher = "Азбука-классика",
                            PublicationYear = "2008", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Критика Чистого Разума", 
                            Author = "Иммануил Кант",
                            Translators = "Н. Лоссков",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Немецкий",
                            Language = "Русский",
                            ISBN = "978-5-699-77120-2",
                            Genre = "Философия",
                            Publisher = "Издательство \"Э\"",
                            PublicationYear = "2017", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Портрет Дориана Грея. Пьессы. Сказки", 
                            Author = "Оскар Уайльд",
                            Translators = "В. Чухно, Н. Гумилева, М. Кузмина, Эллиса",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Английский",
                            Language = "Русский",
                            ISBN = "978-5-699-79501-7",
                            Genre = "Классическая проза",
                            Publisher = "Эксмо",
                            PublicationYear = "2015", 
                            Price = 19 
                        },
                    new Product {
                            Name = "Волкодав. Мир по дороге", 
                            Author = "Мария Семенова",
                            Translators = "none",
                            Description = "Тестовое описание",
                            OriginalLanguage = "Русский",
                            Language = "Русский",
                            ISBN = "978-5-389-07354-8",
                            Genre = "Фантастический роман",
                            Publisher = "Азбука-Аттикус",
                            PublicationYear = "2015", 
                            Price = 19 
                        }
                );
                context.SaveChanges();
            }
        }
    }
}
