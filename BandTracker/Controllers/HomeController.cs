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

		[HttpPost("/bands/new")]
		public ActionResult PostBand()
		{
			Band newBand = new Band(Request.Form["band-name"]);
			newBand.Save();
			List<Band> allBands = Band.GetAll();
			return View("Bands", allBands);
		}

		[HttpPost("/bands/{id}/update")]
		public ActionResult UpdateBand(int id = 0)
		{
			Band updateBand = Band.Find(id);
			string name = Request.Form["band-name"];
			updateBand.SetName(name ?? updateBand.GetName()); // falls back to current name if new one can't be resolved
			updateBand.Update();
			return View("BandView", updateBand);
		}

		[HttpGet("/bands/{id}")]
		public ActionResult BandView(int id)
		{
			return View(Band.Find(id));
		}

		[HttpGet("/bands/{id}/delete")]
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

		[HttpPost("/venues/new")]
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

		[HttpPost("/venues/{id}/update")]
		public ActionResult UpdateVenue(int id = 0)
		{
			Venue updateVenue = Venue.Find(id);
			string name = Request.Form["venue-name"];
			updateVenue.SetName(name ?? updateVenue.GetName());
			updateVenue.Update();
			return View("VenueView", updateVenue);
		}

		[HttpGet("/venues/{id}/delete")]
		public ActionResult VenueDelete(int id)
		{
			Venue.DeleteById(id);
			return View("Venues", Venue.GetAll());
		}

		[HttpGet("/venues/{id}/bandlog")]
		public ActionResult VenueLogBand(int id)
		{
			return View(Venue.Find(id));
		}


		[HttpGet("/venues/{venueId}/bandlog/add/{bandId}")]
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
