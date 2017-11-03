using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;
namespace BandTracker.Tests
{
	[TestClass]
	public class BandTests : IDisposable
	{

		public BandTests()
		{
			DB.DatabaseTest();
		}

		public void Dispose()
		{
			Band.ClearAll();
		}


		[TestMethod]
		public void Save_SavesBandToDatabase_1()
		{
			Band newBand = new Band("The Beatles");
			newBand.Save();

			Assert.AreEqual(1, Band.GetCount());
		}

		[TestMethod]
		public void Find_FindsBandInDatabase_True()
		{
			Band newBand = new Band("The Ink Spots");
			newBand.Save();

			Band foundBand = Band.Find(newBand.GetId());
			Assert.AreEqual(newBand.GetId(), foundBand.GetId());
		}

		[TestMethod]
		public void Update_UpdatesBandInformationInDatabase_false()
		{
			Band newBand = new Band("Some Band");
			newBand.Save();

			newBand.SetName("Not Just Some Band");
			newBand.Update();

			Band foundBand = Band.Find(newBand.GetId());
			Assert.AreNotEqual(foundBand.GetName(), "Some Band");
		}

		[TestMethod]
		public void Delete_DeletesABandFromDatabase_0()
		{
			Band newBand = new Band("Deletables");
			newBand.Save();

			newBand.Delete();
			Assert.AreEqual(0, Band.GetCount());
		}
	}
}
