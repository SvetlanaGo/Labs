using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab2.DAL.Entities;

namespace WebLab2.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Price
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Transport.Price);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="transport">добавляемый объект</param>
        public virtual void AddToCart(Transport transport)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(transport.TransportId))
                Items[transport.TransportId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(transport.TransportId, new CartItem
                {
                    Transport = transport,
                    Quantity = 1
                });
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
