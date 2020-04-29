using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab2.DAL.Data;
using WebLab2.DAL.Entities;

namespace WebLab2.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                      UserManager<ApplicationUser> userManager,
                                      RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");                
            }
            //проверка наличия групп объектов
            if (!context.TransportGroups.Any())
            {
                context.TransportGroups.AddRange(
                new List<TransportGroup>
                {
                     new TransportGroup {GroupName="Фантастический"},
                     new TransportGroup {GroupName="Специальный"},
                     new TransportGroup {GroupName="Красивый"},
                     new TransportGroup {GroupName="Быстрый"},
                     new TransportGroup {GroupName="Веселый"},
                     new TransportGroup {GroupName="Обычный"},
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Transports.Any())
            {
                context.Transports.AddRange(
                new List<Transport>
                {
                     new Transport {TransportName="Пагани",
                     Description="Добавьте, пожалуйста, в «Яндекс.Пробки» слой «Яндекс.Ямки». Очень нужно.",
                     Price =16500, TransportGroupId=3, Image="Пагани.jpg" },
                     new Transport {TransportName="Линкор Айова",
                     Description="Почти как Алые паруса",
                     Price =100000, TransportGroupId=3, Image="Линкор_Айова.jpg" },
                     new Transport {TransportName="Черный дрозд",
                     Description="Птичка со скоростью полета 1 км в секунду",
                     Price =56000, TransportGroupId=4, Image="Черный_дрозд.jpg" },
                     new Transport {TransportName="НЛО",
                     Description="Его прилет станет апофеозом 2020 года",
                     Price =42, TransportGroupId=4, Image="НЛО.jpg" },
                     new Transport {TransportName="Черепаха",
                     Description="В комплектации песня про лежание на солнышке",
                     Price =1, TransportGroupId=5, Image="Черепаха.jpg" },
                     new Transport {TransportName="Машина времени",
                     Description="Актуальная инновационная разработка",
                     Price =90, TransportGroupId=5, Image="Машина_времени.jpg" },
                });
                await context.SaveChangesAsync();
            }
        }

        
    }
}
