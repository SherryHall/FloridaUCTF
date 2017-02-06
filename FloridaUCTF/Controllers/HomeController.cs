﻿using FloridaUCTF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

		[HttpPost]
		public ActionResult Index(SearchViewModel searchRequest)
		{
			var caseParameters = (searchRequest.BusinessName + searchRequest.CaseCity + searchRequest.CaseCounty);
			var caseList = new List<int>();

			if (!string.IsNullOrEmpty(caseParameters))
			{

				var caseQuery = db.Cases.Select(s => new { s.OffenderId, s.BusinessName, s.CaseCity, s.CaseCounty });
				if (!string.IsNullOrEmpty(searchRequest.BusinessName))
				{
					caseQuery = caseQuery.Where(c => c.BusinessName.StartsWith(searchRequest.BusinessName));
				}
				if (!string.IsNullOrEmpty(searchRequest.CaseCounty))
				{
					caseQuery = caseQuery.Where(c => c.CaseCounty.StartsWith(searchRequest.CaseCounty));
				}
				if (!string.IsNullOrEmpty(searchRequest.CaseCity))
				{
					caseQuery = caseQuery.Where(c => c.CaseCity.StartsWith(searchRequest.CaseCity));
				}
				caseList = caseQuery.Select(c => c.OffenderId).ToList();
			}

			//var searchQuery = db.Offenders.Select(o => new { o.Id, o.LastName, o.FirstName, o.FirstAKA, o.LastAKA, o.DriveLicense, o.Cases });
			var searchQuery = db.Offenders.Select(o => new { o.Id, o.LastName, o.FirstName, o.FirstAKA, o.LastAKA, o.DriveLicense, o.Cases });
			if (!string.IsNullOrEmpty(caseParameters))
			{
				searchQuery = searchQuery.Where(o => caseList.Contains(o.Id));
			}
			if (!string.IsNullOrEmpty(searchRequest.LastName) )
			{
				searchQuery = searchQuery.Where(o => o.LastName.StartsWith(searchRequest.LastName));
			}
			if (!string.IsNullOrEmpty(searchRequest.FirstName))
			{
				searchQuery = searchQuery.Where(o => o.FirstName.StartsWith(searchRequest.FirstName));
			}
			if (!string.IsNullOrEmpty(searchRequest.AKA))
			{
				searchQuery = searchQuery.Where(o => o.LastAKA.StartsWith(searchRequest.AKA));
			}
			if (!string.IsNullOrEmpty(searchRequest.DriveLicense))
			{
				searchQuery = searchQuery.Where(o => o.DriveLicense.StartsWith(searchRequest.DriveLicense));
			}

			var searchResults = searchQuery.ToList();
			return View(searchResults);
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
			// This block is following Marks example, but the ViewBag results look odd so trying something else
			//ViewBag.States = db.States.Select(x =>
			//	  new SelectListItem
			//	  {
			//		  Value = x.StateCode,
			//		  Text = x.StateName
			//	  });
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
			newCase.Offender = db.Offenders.Find(offenderId);
			newCase.OffenderAddress = db.OffenderAddresses.Find(currentOffender.DefaultAddressId);
			newCase.OfficialContact = db.Users.Find(HttpContext.User.Identity.GetUserId());
			return View(newCase);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddCase(Case newCase)
		{
			db.Cases.Add(newCase);
			db.SaveChanges();
			return RedirectToAction("CaseCitationDetail", new { caseId = newCase.Id });
		}

		[HttpGet]
		public ActionResult EditCase(int caseId)
		{
			var currCase = db.Cases.Find(caseId);
			return View(currCase);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditCase(Case currCase)
		{
			db.SaveChanges();
			return RedirectToAction("CaseCitationDetail", new { caseId = currCase.Id });
		}


		// GET: Cases/Delete/5
		[HttpGet]
		public ActionResult DeleteCase(int caseId)
		{

			Case delCase = db.Cases.Find(caseId);
			if (delCase == null)
			{
				return HttpNotFound();
			}
			return View(delCase);
		}

		// POST: Cases/Delete/5
		[HttpPost, ActionName("DeleteCase")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int caseId)
		{
			Case delCase = db.Cases.Find(caseId);
			db.Cases.Remove(delCase);
			db.SaveChanges();
			return RedirectToAction("AllOffenderCases", new { offenderId = delCase.OffenderId });
		}



		[HttpGet]
		public ActionResult _AddCitation(int caseId)
		{
			var newCitation = new Citation();
			newCitation.CaseId = caseId;
			return PartialView(newCitation);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult _AddCitation(Citation newCitation)
		{
			newCitation.ActionId = 1;
			newCitation.RulingId = 1;
			db.Citations.Add(newCitation);
			db.SaveChanges();
			return RedirectToAction("CaseCitationDetail", new { caseId = newCitation.CaseId });
		}


		// GET: Citations/Edit/5
		[HttpGet]
		public ActionResult _EditCitation(int citationId)
		{

			var currCitation = db.Citations.Find(citationId);
			if (currCitation == null)
			{
				return HttpNotFound();
			}

			return PartialView(currCitation);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult _EditCitation([Bind(Include = "Id,CitationNumber,StatuteOrdinance,Description,Withheld,Probation,PrivilegeRevoked,FineAmount,RestitutionAmount,CaseId,ActionId,RulingId,CreateDate,CreatorId,Creator,ChangeDate,LastChangerId,Changer")] Citation citation)
		{
			if (ModelState.IsValid)
			{
				db.Entry(citation).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("CaseCitationDetail", new { caseId = citation.CaseId });
			}

			return PartialView(citation);
		}

		// GET: Citations/Delete/5
		[HttpGet]
		public ActionResult _DeleteCitation(int citationId)
		{

			Citation citation = db.Citations.Find(citationId);
			if (citation == null)
			{
				return HttpNotFound();
			}
			return PartialView(citation);
		}

		// POST: Citations/Delete/5
		[HttpPost, ActionName("_DeleteCitation")]
		[ValidateAntiForgeryToken]
		public ActionResult _DeleteCitConfirmed(int citationId)
		{
			Citation citation = db.Citations.Find(citationId);
			db.Citations.Remove(citation);
			db.SaveChanges();
			return RedirectToAction("CaseCitationDetail", new { caseId = citation.CaseId });
		}

		[HttpGet]
		public ActionResult CaseCitationDetail(int caseId)
		{
			//var currentCase = db.Cases.Include("Offender").First(f => f.Id == caseId);
			var currentCase = db.Cases.First(f => f.Id == caseId);
			return View(currentCase);
		}


		[HttpGet]
		public ActionResult AllOffenderDetail(int offenderId)
		{
			// Load Select Options for the Actions drop down
			//ViewBag.Actions = db.Actions.Select(x =>
			//	 new SelectListItem
			//	 {
			//		  Value = x.Id.ToString(),
			//		  Text = x.Description
			//	  });
			ViewBag.ActionsList = db.Actions.Select(x => new { x.Id, x.Description}).ToList();

			// Load Select Options for the Rulings drop down
			//ViewBag.Rulings = db.Rulings.Select(x =>
			//	 new SelectListItem
			//	 {
			//		 Value = x.Id.ToString(),
			//		 Text = x.Description
			//	 });

			ViewBag.RulingsList = db.Rulings.Select(x => new { x.Id, x.Description }).ToList();

			//var currentCase = db.Cases.Include("Offender").First(f => f.Id == caseId);
			var currentOffender = db.Offenders.First(f => f.Id == offenderId);
			return View(currentOffender);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SaveVerdictChanges (Offender currOffender)
		{
			foreach (var currCase in currOffender.Cases)
			{
				foreach (var citation in currCase.Citations)
				{
					//db.SaveChanges(citation);
				}
			}

			return RedirectToAction("AllOffenderDetail.cshtml", new { offenderId = currOffender.Id });
		}



		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);

		}
	}
}