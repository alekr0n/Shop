using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
	public class HomeController : Controller
	{
		private IAllCars _carRep;

		public HomeController(IAllCars carRep)
		{
			_carRep = carRep;
		}

		public ViewResult Index()
		{
			var homeCars = new HomeViewModel
			{
				favCars = _carRep.GetFavouriteCars
			};
			return View(homeCars);
		}
	}
}
