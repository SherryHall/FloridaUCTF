using FloridaUCTF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloridaUCTF.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public ActionResult Index()
		{
			var searchRequest = new SearchViewModel();
			return View(searchRequest);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		[HttpGet]
		public ActionResult AddOffender()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public ActionResult AddOffender([Bind(Include = "Id,LastName,FirstName,MiddleName,DriveLicense,DriveLicenseState,LastAKA,FirstAKA,Street,City,State,Zip")] AddOffenderViewModel offenderInfo)
		public ActionResult AddOffender(AddOffenderViewModel offenderInfo)
		{
			// Save Offender. create newOffender to get Offender Id to plug into Address record
			var newOffender = db.Offenders.Add(offenderInfo.Offender);
			db.SaveChanges();

			// Set the Offender for this address and save. create newAddress to get Address Id to plug into Offender record
			offenderInfo.OffenderAddress.OffenderId = offenderInfo.Offender.Id;
			var newAddress = db.OffenderAddresses.Add(offenderInfo.OffenderAddress);
			db.SaveChanges();

			// update the Offender record to the DefaultAddress to the address record just saved above.
			newOffender.DefaultAddressId = newAddress.Id;
			db.SaveChanges();
			
			return RedirectToAction("AddCase", new { offenderId = newOffender.Id });
		}
		[HttpGet]
		public ActionResult AddCase(int offenderId)
		{
			var currentOffender = db.Offenders.Find(offenderId);

			var newCase = new Case();
			newCase.OffenderAddress = db.OffenderAddresses.Find(currentOffender.Id);
			newCase.OfficialContact = db.Users.Find(HttpContext.User.Identity.GetUserId());
			return View(newCase);
		}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult AddCase(Case case)
		//{

		//	return View();
		//}
	}
}