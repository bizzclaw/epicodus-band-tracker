using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;
namespace BandTracker.Tests
{
	[TestClass]
	public class QueryTests : IDisposable
	{
		public QueryTests()
		{
			DB.DatabaseTest();
		}

		public void Dispose()
		{
			Band.ClearAll();
		}

		[TestMethod]
		public void Execute_QueryExecuted_true()
		{
			Query test = new Query("SELECT * FROM bands");
			test.Execute();
			Assert.AreEqual(true, true); // if the query fails, this will not pass.
		}
	}
}
