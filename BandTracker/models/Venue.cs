using System;
using System.Collections.Generic;

namespace BandTracker.Models
{
	public class Venue
	{
		private int _id;
		public void SetId(int id) {_id = id;}
		public int GetId() {return _id;}

		private string _name;
		public void SetName(string name) {_name = name;}
		public string GetName() {return _name;}

		public Venue(string name, int id = 0)
		{
			SetName(name);
			SetId(id);
		}

		public void Save()
		{
			Query saveVenue = new Query("INSERT INTO venues (name) VALUES (@name)");
			saveVenue.AddParameter("@name", GetName());
			saveVenue.Execute();
			SetId((int)saveVenue.GetCommand().LastInsertedId);
		}

		public static int GetCount()
		{
			Query countVenues = new Query("SELECT COUNT(*) FROM venues");
			var rdr = countVenues.Read();
			while (rdr.Read())
			{
				return rdr.GetInt32(0);
			}
			return 0;
		}

		public static void ClearAll()
		{
			Query clearVenues = new Query("DELETE FROM venues");
			clearVenues.Execute();
		}

		public static Venue Find(int id)
		{
			Query matchedVenue = new Query("SELECT * FROM venues WHERE id = @searchId");
			matchedVenue.AddParameter("@searchId", id.ToString());
			var rdr = matchedVenue.Read();
			int matchId = 0;
			string matchName = "";
			while (rdr.Read())
			{
				matchId = rdr.GetInt32(0);
				matchName = rdr.GetString(1);
			}
			Venue venueMatch = new Venue(matchName, matchId);
			return venueMatch;
		}

		public void Update()
		{
			Query updateVenue = new Query("UPDATE venues SET name = @updateName WHERE id = @venueId;");
			updateVenue.AddParameter("@updateName", GetName());
			updateVenue.AddParameter("@venueId", GetId().ToString());
			updateVenue.Execute();
		}

		public static void DeleteById(int id)
		{
			Query deleteVenue = new Query("DELETE FROM venues WHERE id = @venueId");
			deleteVenue.AddParameter("@venueId", id.ToString());
			deleteVenue.Execute();
		}
		public void Delete()
		{
			DeleteById(GetId());
		}


		public static List<Venue>GetAll()
		{
			List<Venue> allVenues = new List<Venue> {};
			Query getAllVenues = new Query("SELECT * FROM venues");
			var rdr = getAllVenues.Read();
			while(rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				Venue newVenue = new Venue(name, id);
				allVenues.Add(newVenue);
			}
			return allVenues;
		}
	}
}
