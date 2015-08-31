using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseConnection
{
	public static class DatabaseController
	{
		static SqlConnection connection;

		public static bool OpenConnection()
		{
			connection = 
				new SqlConnection("server=ealdb1.eal.local;uid=ejl10_usr;" +
            "pwd=Baz1nga10;database=EJL10_DB;");
			try
			{
				connection.Open();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
		public static void CloseConnection()
		{
			connection.Close();
		}

		public static bool DoUserExist(string user)
		{
			try
			{
				OpenConnection();

				SqlCommand cmd = new SqlCommand("if exists(select id from " + 
					"stpn_users where [USER] = @USER) select 1 else " +
					"select 0", connection);
				cmd.Parameters.Add("@USER", SqlDbType.NVarChar).Value = user;
				cmd.ExecuteNonQuery();

				SqlDataReader reader = cmd.ExecuteReader();

				bool result = Convert.ToBoolean(reader.Read());

				CloseConnection();

				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static bool CreateNewUser(string user)
		{
			return true;
		}
	}
}
