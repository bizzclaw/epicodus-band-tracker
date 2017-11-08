using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;
namespace BandTracker.Tests
{
	[TestClass]
	public class VenueTests : IDisposable
	{

		public VenueTests()
		{
			DB.DatabaseTest();
		}

		public void Dispose()
		{
			Venue.ClearAll();
			Band.ClearAll();
		}


		[TestMethod]
		public void Save_SavesVenueToDatabase_1()
		{
			Venue newVenue = new Venue("Rose Garden");
			newVenue.Save();

			Assert.AreEqual(1, Venue.GetCount());
		}

		[TestMethod]
		public void Find_FindsVenueInDatabase_True()
		{
			Venue newVenue = new Venue("Red Rock Ampitheatre");
			newVenue.Save();

			Venue foundVenue = Venue.Find(newVenue.GetId());
			Assert.AreEqual(newVenue.GetId(), foundVenue.GetId());
		}

		[TestMethod]
		public void Update_UpdatesVenueInformationInDatabase_false()
		{
			Venue newVenue = new Venue("Radio City");
			newVenue.Save();

			newVenue.SetName("Radio City Music Hall");
			newVenue.Update();

			Venue foundVenue = Venue.Find(newVenue.GetId());
			Assert.AreNotEqual(foundVenue.GetName(), "Radio City");
		}

		[TestMethod]
		public void Delete_DeletesAVenueFromDatabase_0()
		{
			Venue newVenue = new Venue("A Bad Place");
			newVenue.Save();

			newVenue.Delete();
			Assert.AreEqual(0, Venue.GetCount());
		}

		[TestMethod]
		public void LogBandAndGetBandLog_LogBandInVenueAndGetItFromLog_1()
		{
			Venue newVenue = new Venue("A Cool Place");
			newVenue.Save();

			Band dummyBand = new Band("NotCool Guys");
			dummyBand.Save();

			Band newBand = new Band("Cool Guys");
			newBand.Save();

			newVenue.LogBand(newBand);
			List<Band> bandLog = newVenue.GetBandLog();
			Assert.AreEqual(1, bandLog.Count);
		}
	}
}
