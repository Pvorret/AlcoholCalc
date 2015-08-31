using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;


namespace LoginTest
{
    [TestClass]
    public class UnitTest1
    {
        Login.Login l = new Login.Login(new Person.Person("Phillip"));

        [TestMethod]
        public void U_Login_CreateNewUser_Name_Success()
        {
            bool failed = false;
            
            try
            {
                l.CreateUser("Pvorret", "Hej1");   
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                failed = true;
            }
            Assert.IsFalse(failed);
        }
        [TestMethod]
        public void U_Login_CreateUser_Empty()
        {
            string response;
            try
            {
                response = l.CreateUser("", "");   
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                response = "No";
            }
            Assert.AreEqual("You need input a better UserName or Password", response);

        }
        [TestMethod]
        public void U_Login_LoginResponse_Empty()
        {
            bool failed = true;
            try
            {
                failed = l.LoginResponse("", "");
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                failed = false;
            }

            Assert.IsFalse(failed);
        }
        [TestMethod]
        public void U_Login_LoginRespons()
        {
            bool worked;

            try
            {
                l._users.Add("Pvorret", "Hej1");
                worked = l.LoginResponse("Pvorret", "Hej1");
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                worked = false;
            }
            Assert.IsTrue(worked);
        }


    }
}
