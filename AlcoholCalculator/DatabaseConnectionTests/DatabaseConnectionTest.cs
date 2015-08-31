using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using DatabaseConnection;
using System.Data;

namespace DatabaseConnectionTests
{
	[TestClass]
	public class DatabaseConnectionTest
	{
		[TestMethod]
		public void U_DatabaseConnection_Connection()
		{
			Assert.AreEqual(true, DatabaseController.OpenConnection());

			DatabaseController.CloseConnection();
		}

		[TestMethod]
		public void U_DatabaseConnection_DoUserExist_UserString()
		{
			SqlConnection connection =
				new SqlConnection("server=ealdb1.eal.local; uid = ejl10_usr; " +
						"pwd=Baz1nga10;database=EJL10_DB;");

			connection.Open();

			SqlCommand cmd = new SqlCommand("INSERT INTO stpn_users ([USER])" +
				"values (@USER)", connection);
			cmd.Parameters.Add("@USER", SqlDbType.NVarChar).Value = "test test";
			cmd.ExecuteNonQuery();
			connection.Close();

			Assert.AreEqual(true, DatabaseController.DoUserExist("test test"));

			Assert.AreNotEqual(false, DatabaseController.DoUserExist("test2 test2"));

			connection.Open();

			cmd = new SqlCommand("DELETE FROM stpn_users " +
				"WHERE [USER] = 'test test'", connection);
			cmd.ExecuteNonQuery();

			connection.Close();
    }

    [TestMethod]
		public void U_DatabaseConnection_CreateNewUser_UserString()
		{
			DatabaseController.CreateNewUser("test test");

			SqlConnection connection =
				new SqlConnection("server=ealdb1.eal.local; uid = ejl10_usr; " +
						"pwd=Baz1nga10;database=EJL10_DB;");

			connection.Open();

			string result = 


		}
	}
}
