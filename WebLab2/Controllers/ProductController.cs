using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab2.DAL.Entities;
using WebLab2.Extensions;
using WebLab2.Models;
using WebLab2.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLab2.Controllers
{
    public class ProductController : Controller
    {
        //public List<Transport> _transports;
        //List<TransportGroup> _transportGroups;

        ApplicationDbContext _context;
        int _pageSize;
        //public ProductController()

        //private ILogger _logger;
        public ProductController(ApplicationDbContext context/*,
                                 ILogger<ProductController> logger*/)
        {
            _pageSize = 3;
            //SetupData();
            _context = context;
            //_logger = logger;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            //var items = _transports
            //.Skip((pageNo - 1) * _pageSize)
            //.Take(_pageSize)
            //.ToList();
            //return View(items);

            var groupMame = group.HasValue
                ? _context.TransportGroups.Find(group.Value)?.GroupName
                : "all groups";
            //_logger.LogInformation($"info: group={group}, page={pageNo}");

            //var transportsFiltered = _transports
            var transportsFiltered = _context.Transports
            .Where(d => !group.HasValue || d.TransportGroupId == group.Value);

            // Поместить список групп во ViewData
            //ViewData["Groups"] = _transportGroups;
            ViewData["Groups"] = _context.TransportGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            //return View(ListViewModel<Transport>.GetModel(transportsFiltered, pageNo, _pageSize));

            var model = ListViewModel<Transport>.GetModel(transportsFiltered, pageNo, _pageSize);
            //if (Request.Headers["x-requested-with"]
            //.ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_listpartial", model);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        //private void SetupData()
        //{
        //    _transportGroups = new List<TransportGroup>
        //    {
        //     new TransportGroup {TransportGroupId=1, GroupName="Фантастический"},
        //     new TransportGroup {TransportGroupId=2, GroupName="Специальный"},
        //     new TransportGroup {TransportGroupId=3, GroupName="Красивый"},
        //     new TransportGroup {TransportGroupId=4, GroupName="Быстрый"},
        //     new TransportGroup {TransportGroupId=5, GroupName="Веселый"},
        //     new TransportGroup {TransportGroupId=6, GroupName="Обычный"},
        //    };
        //    _transports = new List<Transport>
        //    {             
        //     new Transport {TransportId = 1, TransportName="Пагани",
        //     Description="Добавьте, пожалуйста, в «Яндекс.Пробки» слой «Яндекс.Ямки». Очень нужно.",
        //     Price =16500, TransportGroupId=3, Image="Пагани.jpg" },
        //     new Transport {TransportId = 2, TransportName="Линкор Айова",
        //     Description="Почти как Алые паруса",
        //     Price =100000, TransportGroupId=3, Image="Линкор_Айова.jpg" },
        //     new Transport {TransportId = 3, TransportName="Черный дрозд",
        //     Description="Птичка со скоростью полета 1 км в секунду",
        //     Price =56000, TransportGroupId=4, Image="Черный_дрозд.jpg" },
        //     new Transport {TransportId = 4, TransportName="НЛО",
        //     Description="Его прилет станет апофеозом 2020 года",
        //     Price =42, TransportGroupId=4, Image="НЛО.jpg" },
        //     new Transport {TransportId = 5, TransportName="Черепаха",
        //     Description="В комплектации песня про лежание на солнышке",
        //     Price =1, TransportGroupId=5, Image="Черепаха.jpg" },
        //     new Transport {TransportId = 6, TransportName="Машина времени",
        //     Description="Актуальная инновационная разработка",
        //     Price =90, TransportGroupId=5, Image="Машина_времени.jpg" },
        //    };
        //}
    }
}