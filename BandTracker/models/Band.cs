using System;
using System.Collections.Generic;

namespace BandTracker.Models
{
	public class Band
	{
		private int _id;
		public void SetId(int id) {_id = id;}
		public int GetId() {return _id;}

		private string _name;
		public void SetName(string name)
		{
			_name = name ?? "ERROR";
		}
		public string GetName() {return _name;}

		public Band(string name, int id = 0)
		{
			SetName(name);
			SetId(id);
		}

		public void Save()
		{
			Query saveBand = new Query("INSERT INTO bands (name) VALUES (@name)");
			saveBand.AddParameter("@name", GetName());
			saveBand.Execute();
			SetId((int)saveBand.GetCommand().LastInsertedId);
		}

		public static int GetCount()
		{
			Query countBands = new Query("SELECT COUNT(*) FROM bands");
			var rdr = countBands.Read();
			while (rdr.Read())
			{
				return rdr.GetInt32(0);
			}
			return 0;
		}

		public static void ClearAll()
		{
			Query clearBands = new Query("DELETE FROM bands");
			clearBands.Execute();
		}

		public static Band Find(int id)
		{
			Query matchedBand = new Query("SELECT * FROM bands WHERE id = @searchId");
			matchedBand.AddParameter("@searchId", id.ToString());
			var rdr = matchedBand.Read();
			int matchId = 0;
			string matchName = "";
			while (rdr.Read())
			{
				matchId = rdr.GetInt32(0);
				matchName = rdr.GetString(1);
			}
			Band bandMatch = new Band(matchName, matchId);
			return bandMatch;
		}

		public void Update()
		{
			Query updateBand = new Query("UPDATE bands SET name = @updateName WHERE id = @bandId;");
			updateBand.AddParameter("@updateName", GetName());
			updateBand.AddParameter("@bandId", GetId().ToString());
			updateBand.Execute();
		}

		public static void DeleteById(int id)
		{
			Query deleteBand = new Query("DELETE FROM bands WHERE id = @bandId; DELETE FROM bands_venues WHERE band_id = @bandId");
			deleteBand.AddParameter("@bandId", id.ToString());
			deleteBand.Execute();
		}
		public void Delete()
		{
			DeleteById(GetId());
		}


		public static List<Band>GetAll()
		{
			List<Band> allBands = new List<Band> {};
			Query getAllBands = new Query("SELECT * FROM bands");
			var rdr = getAllBands.Read();
			while(rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				Band newBand = new Band(name, id);
				allBands.Add(newBand);
			}
			return allBands;
		}

		public List<Venue> GetVenueLog()
		{
			Query getLog = new Query(@"
				SELECT venues.* FROM venues
					JOIN (bands_venues)
					ON bands_venues.venue_id = venues.id
				WHERE bands_venues.band_id = @bandId;
			");
			getLog.AddParameter("@bandId", GetId().ToString());
			var rdr = getLog.Read();
			List<Venue> venueLog = new List<Venue> {};
			while (rdr.Read())
			{
				Venue foundVenue = new Venue(rdr.GetString(1), rdr.GetInt32(0));
				venueLog.Add(foundVenue);
			}
			return venueLog;
		}
	}
}
