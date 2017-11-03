using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BandTracker.Models;

namespace BandTracker.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet("/bands")]
		public ActionResult Bands()
		{
			return View(Band.GetAll());
		}

		[HttpGet("/bands/new")]
		public ActionResult NewBand()
		{
			return View();
		}

		[HttpPost("/bands/postnew")]
		public ActionResult PostBand()
		{
			Band newBand = new Band(Request.Form["band-name"]);
			newBand.Save();
			List<Band> allBands = Band.GetAll();
			return View("Bands", allBands);
		}

		[HttpGet("/bands/{id}")]
		public ActionResult BandView(int id)
		{
			return View(Band.Find(id));
		}

		[HttpGet("/bands/delete/{id}")]
		public ActionResult BandDelete(int id)
		{
			Band.DeleteById(id);
			return View("Bands", Band.GetAll());
		}

		[HttpGet("/venues")]
		public ActionResult Venues()
		{
			return View(Venue.GetAll());
		}

		[HttpGet("/venues/new")]
		public ActionResult NewVenue()
		{
			return View();
		}

		[HttpPost("/venues/postnew")]
		public ActionResult PostVenue()
		{
			string name = Request.Form["venue-name"];
			Venue newVenue = new Venue(name);
			newVenue.Save();
			return View("Venues", Venue.GetAll());
		}

		[HttpGet("/venues/{id}")]
		public ActionResult VenueView(int id)
		{
			return View(Venue.Find(id));
		}

		[HttpGet("/venues/delete/{id}")]
		public ActionResult VenueDelete(int id)
		{
			Venue.DeleteById(id);
			return View("Venues", Venue.GetAll());
		}

		[HttpGet("/venues/logband/{id}")]
		public ActionResult VenueLogBand(int id)
		{
			return View(Venue.Find(id));
		}


		[HttpGet("/venues/{venueId}/post-band-log/{bandId}")]
		public ActionResult PostVenueLogBand(int venueId, int bandId)
		{
			Band loggedBand = Band.Find(bandId);
			if (loggedBand != null)
			{
				Venue loggingVenue = Venue.Find(venueId);
				loggingVenue?.LogBand(loggedBand);
				return View("VenueView", loggingVenue);
			}
			else
			{
				return View("Venues", Venue.GetAll());
			}
		}
	}
}
