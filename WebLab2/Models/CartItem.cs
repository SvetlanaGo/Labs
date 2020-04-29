using WebLab2.DAL.Entities;

namespace WebLab2.Models
{
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Transport Transport { get; set; }
        public int Quantity { get; set; }
    }
}