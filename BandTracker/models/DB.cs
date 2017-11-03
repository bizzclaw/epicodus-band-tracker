using System;
using MySql.Data.MySqlClient;

namespace BandTracker.Models
{
	public class DB
	{
		public static void DatabaseTest()
		{
			DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=band_tracker;";
			// DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker;";
		}

		public static MySqlConnection Connection()
		{
			MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
			return conn;
		}
	}
}
