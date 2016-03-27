using System;
using Oracle.ManagedDataAccess.Client;

namespace TestOracleManaged
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string conString = "User Id=brad; password=xxxx;" +

				//EZ Connect Format is [hostname]:[port]/[service_name]
				//Examine working TNSNAMES.ORA entries to find these values
			                   "Data Source=192.168.52.131:1521/xe; Pooling=false;";

			//Create a connection to Oracle

			OracleConnection con = new OracleConnection ();
			con.ConnectionString = conString;
			con.Open ();

			Console.WriteLine ("Connected to Oracle Database {0}", con.ServerVersion);

			//Create a command within the context of the connection
			//Use the command to display employee names and salary from Employees table
			OracleCommand cmd = con.CreateCommand ();
			cmd.CommandText = "select * from dual";

			//Execute the command and use datareader to display the data
			OracleDataReader reader = cmd.ExecuteReader ();
			while (reader.Read ()) {
				Console.WriteLine ("Test: " + reader.GetString (0));           
			}
			Console.WriteLine ("Hello World!");
		}
	}
}
