using System;
using System.Collections.Generic;
using System.Text;

namespace WebLab2.DAL.Entities
{
    public class Transport
    {
        public int TransportId { get; set; } // id транспорта
        public string TransportName { get; set; } // название транспорта
        public string Description { get; set; } // описание транспорта
        public int Price { get; set; } // цена
        public string Image { get; set; } // имя файла изображения
        // Навигационные свойства
        /// <summary>
        /// группа транспорта 
        /// </summary>
        public int TransportGroupId { get; set; }
        public TransportGroup Group { get; set; }
    }
}
