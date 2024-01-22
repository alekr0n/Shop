using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartID = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItem()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartID == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
