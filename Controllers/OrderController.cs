using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Chekout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Chekout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItem();

            if(shopCart.listShopItems.Count == 0) {
                ModelState.AddModelError("", "Busket empty");
            }

            allOrders.createOrder(order);
            return RedirectToAction("Complete");

            return View(order);
        }

        public IActionResult Complete() 
        {
            ViewBag.Message = "The order has been successfully placed";
            return View();
        }
    }
}
