using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesAndSeriesApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UnitTesting
    {
        CPManager cp = new CPManager();
        UserManager um = new UserManager(); 
        CPDBManager db = new CPDBManager();


        //Checking if the given release date of the cinematic production is valid
        [TestMethod]
        public void CheckDate()
        {
            Assert.IsFalse(cp.CheckDate("201221-2-13"));
        }


        //Checking if the user with right credentials can successfully log in
        [TestMethod]
        public void CheckUserCorrectCredentials()
        {
            Assert.IsTrue(um.CheckUsername("cuci"));
            Assert.IsTrue(um.CheckPassword("cuci", "4321"));
        }


        //Checking if the user is denied acces when providing wrong password
        [TestMethod]
        public void CheckUserWrongPassword()
        {
            Assert.IsFalse(um.CheckPassword("cuci", "1234"));
        }


        //Checking if the user is denied acces when providing wrong username
        [TestMethod]
        public void CheckUserWrongUsername()
        {
            Assert.IsFalse(um.CheckUsername("cecka"));
        }


        //checking if a user is denied access when providing no information for log in
        [TestMethod]
        public void CheckUserWrongCredentials()
        {
            Assert.IsFalse(um.CheckPassword("", ""));
            Assert.IsFalse(um.CheckUsername(""));
        }


        //Checking if the username for registration is already taken by someone
        [TestMethod]
        public void CreateAccountTakenUsername()
        {
            Assert.IsFalse(um.TakenUsername("cuci"));
        }


        //Checking if the given by the user email is valid
        [TestMethod]
        public void CreateAccountInvalidEmail()
        {
            Assert.IsFalse(um.ValidEmail("1"));
        }


        //Checking if the confirmation of the password when creating an account matches the password
        [TestMethod]
        public void CreateAccountDifferentPassword()
        {
            Assert.IsFalse(um.SamePassword("1234", "4321"));
        }


        //Checking if the creation of an account when provided valid info is successfull
        [TestMethod]
        public void CreateAccountSuccessful()
        {
            Assert.IsTrue(um.Register("pesho", "pesho@gmail.com", "1234", "Pesho", "1"));
        }


        //Testing if the method for getting the type of an account works (0 - manager; 1 - regular user)
        [TestMethod]
        public void GetTypeAcc()
        {
            Assert.AreEqual(1, um.GetTypeOfAcc("cuci"));
        }
        

        //Testing if editing an account information is successfull and if the method for getting a userby their username works
        [TestMethod]
        public void TestEditUserInfo()
        {
            um.EditInfo(um.GetUser("kali_slunce01").Id, "kali_slunce", "1234", "kali@gmail.com", "+359 12345678");

            User user = um.GetUser("kali_slunce");

            Assert.AreEqual(user.Password, "1234");
            Assert.AreEqual(user.Email, "kali@gmail.com");
            Assert.AreEqual(user.PhoneNumber, "+359 12345678");
        }

        //Testing if the searchbar gets the cinematic production having part of their names
        [TestMethod]
        public void TestGetCP()
        {
            Movie movie = new Movie(1, "Fast and Furious", "Cool movie", "2020-12-01", 123, 200, "Netflix");
            Movie movie2 = new Movie(100, "Fast and Furious 2", "Cool movie", "2020-12-01", 123, 200, "Netflix");

            cp.Productions.Add(movie);
            cp.Productions.Add(movie2);

            List<MoviesAndSeriesApplication.CinematicProduction> compareCP = new List<CinematicProduction>();
            compareCP.Add(movie);
            compareCP.Add(movie2);

            CollectionAssert.AreEqual(cp.GetByPartialName("Fast"), compareCP) ;
        }


        //Testing if editing a particular movie's details is successful
        [TestMethod]
        public void TestEditingMovieInfo()
        {
            cp.UpdateMovieInfo((Movie)cp.GetName("Uncharted"), "Uncharted!", "Street-smart Nathan Drake is recruited by seasoned treasure hunter Victor 'Sully' Sullivan to recover a fortune amassed by Ferdinand Magellan, and lost 500 years ago by the House of Moncada.", "Netflix", "2022-03-17", 116, 120000000);

            Assert.AreEqual((Movie)cp.GetName("Uncharted"), null);
        }

        //Testing if editing a particular TV Show's details is successful
        [TestMethod]
        public void TestEditingTVShowInfo()
        {
            cp.UpdateTVShowInfo((TVShow)cp.GetName("Friends"), "Friends!", "Follows the personal and professional lives of six twenty to thirty-something-year-old friends living in Manhattan.", "Netflix", "1994-09-22", 10, 236);

            Assert.AreEqual((TVShow)cp.GetName("Friends"), null);
        }


        //Testing if the method of retrieving the id of a particular cp 
        [TestMethod]
        public void TestGetId()
        {
            Assert.AreEqual(db.GetID("Avengers"), 2);
        }

        //TEsting if removing a cp is successful
        [TestMethod]
        public void TestRemovingCP()
        {
            //The TVShow I added has the title "1" and the id 53

            cp.RemoveCP(54);

            Assert.AreEqual(db.GetID("1"), 0);
        }
    }
    

}