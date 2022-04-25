using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesAndSeriesApplication;
using LogicLayer;
using Entities;
using DataAccessLayer;
using System.Collections.Generic;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTesting
    {
        //Tests for the cinematic productions logic layer

        CPManager cpm = new CPManager(new MovieDBMock(), new TVShowDBMock(), new CPDBMock());

        [TestMethod]
        public void TestGetCPById()
        {
            //Checks the method for retrieving a production from the collection with the previously added productions in the mock db
            Assert.IsInstanceOfType(cpm.GetCP(1), typeof(Movie));
            Assert.IsInstanceOfType(cpm.GetCP(5), typeof(TVShow));
        }


        [TestMethod]
        public void TestAddCP()
        {
            CinematicProduction cp = new Movie(9, "i want a new tattoo so bad", "donate to the cause", "2022-04-23", 123, 456, "dealer's choice", null, new MovieDBMock());

            //Checks if the adding method returns true
            Assert.IsTrue(cpm.AddCP(cp));

            //Checks if the newly added production is added to the list by searching in the collection by its id
            Assert.AreSame((Movie)cp, cpm.GetCP(9));

        }

        [TestMethod]
        public void TestRemoveCP()
        {
            CinematicProduction cp = new TVShow(10, "my money don't jiggle jiggle", "it folds", "2012-09-23", "i like to see u wiggle wiggle", 12, 345, null, new TVShowDBMock());

            //Checks if the removing method returns true
            Assert.IsTrue(cpm.RemoveCP(cp));

            //Checks if the newly added production is added to the list by searching in the collection by its id
            Assert.IsNull(cpm.GetCP(10));
        }

        [TestMethod]
        public void TestUpdateCP()
        {
            CinematicProduction oldCP = new Movie(11, "idk if i'm doin this right", "but imma do it anyways", "2012-08-23", 123, 23456, "send help", null, new MovieDBMock());

            cpm.AddCP(oldCP);

            CinematicProduction updatedCP = new Movie(11, "idk if i'm doin this right pt2", "but imma do it anyways hehe", "2012-08-23", 123, 23456, "send help", null, new MovieDBMock());

            //Checks if the updating method returns true
            Assert.IsTrue(cpm.UpdateCP(updatedCP));

            //Checks if the updated movie is the same as the one in the collection and if the old is not
            Assert.AreSame((Movie)updatedCP, cpm.GetCP(11));
            Assert.AreNotSame(cpm.GetCP(11), (Movie)oldCP);

        }


        [TestMethod]
        public void TestCheckDate()
        {
            Assert.IsFalse(cpm.CheckDate("29185-32-45"));
        }

        [TestMethod]
        public void TestGetByPartialName()
        {
            CinematicProduction cp1 = new Movie(12, "name1", "fml", "2012-12-09", 123, 234, "i'm hungry fr", null, new MovieDBMock());
            CinematicProduction cp2 = new TVShow(13, "name2", "hehehhe", "2012-09-23", "riding in my fiat", 12, 23, null, new TVShowDBMock());

            //Creating a list that contains only the two productions with similar names
            List<CinematicProduction> TestList = new List<CinematicProduction>();

            TestList.Add(cp1);
            TestList.Add(cp2);

            //Adding the productions to the real list
            cpm.AddCP(cp1);
            cpm.AddCP(cp2);

            //Checks if the method returns a list with the same productions that partially contain this name
            CollectionAssert.AreEqual(TestList, cpm.GetByPartialName("name"));
           
        }











        //Tests for the user logic layer

        UserManager um = new UserManager(new UserDBMock(), new UserDBMock());

        [TestMethod]
        public void TestGetUserByUsername()
        {
            //Checks if the method successfully retrieves a user by their username from the collection
            Assert.IsNotNull(um.GetUser("radka"));
        }

        [TestMethod]
        public void TestCheckUsername()
        {
            //Checks if the collection of users contains the given username
            Assert.IsFalse(um.CheckUsername("cuca"));
            Assert.IsTrue(um.CheckUsername("radka"));
        }

        [TestMethod]
        public void TestCheckPassword()
        {
            //Checks of the username and the password match
            Assert.IsTrue(um.CheckPassword("radka", "1234"));
            Assert.IsFalse(um.CheckPassword("radka", "123"));
        }

        [TestMethod]
        public void TestRegisterNewUser()
        {
            string[] pass = um.GetPass("1234");

            User newUser = new User(2, 1, "cvetaa", pass[1], "juicy_cveta", "ceca", "1", pass[0]);

            um.Register(newUser);

            //Checks if the user was successfully added to the collection by retrieving their info by their username
            Assert.AreSame(newUser, um.GetUser("cvetaa"));
        }

        [TestMethod]
        public void TestHashPassword()
        {
            string[] pass = um.GetPass("4321");

            User newUser = new User(3, 1, "vikee", pass[1], "viki_03", "viktoriqq", "1", pass[0]);

            //Registering the newly created user so check if the hashing when creating a new account is successfull
            um.Register(newUser);

            //Tests for successfull hashing
            Assert.IsTrue(um.CheckPassword("vikee", "4321"));
            Assert.AreNotEqual(newUser.Password, "4321");
        }
        
        [TestMethod]
        public void TestValidEmail()
        {
            Assert.IsFalse(um.ValidEmail("123dfjo"));
            Assert.IsTrue(um.ValidEmail("radolina@gmail.com"));
        }

        [TestMethod]
        public void TestHashSameSalt()
        {
            //Creating and registering a new user
            string[] pass = um.GetPass("4321");

            User oldUser = new User(7, 1, "vancheto", pass[1], "viki_03", "viktoriqq", "1", pass[0]);

            um.Register(oldUser);

            //Creating a new user with the edited info but same id
            User newUser = new User(7, 1, "vancheto_2", um.HashNewPass("1234", um.GetUser("vancheto")), "viki_03", "viktoriqq", "1", um.GetUser("vancheto").Salt);
            
            
            //Tests if editing the user password with the same salt is successful
            um.EditInfo(newUser);

            Assert.IsFalse(um.CheckPassword("vancheto_2", "4321"));
            Assert.IsTrue(um.CheckPassword("vancheto_2", "1234"));
        } 

        [TestMethod]
        public void TestEditUserInfo()
        {
            //Creating and registering a new user
            string[] pass = um.GetPass("1234");

            User oldUser = new User(4, 1, "stoil", pass[1], "plovdivski_pruch", "stoikata", "1", pass[0]);
            um.Register(oldUser);


            //Editing the info of the created user
            User editedUser = new User(4, 1, "sussel", pass[1], "plovdivski_pruch", "stoikata", "1", pass[0]);
            um.EditInfo(editedUser);

            Assert.IsNull(um.GetUser("stoil"));
            Assert.AreEqual(editedUser, um.GetUser("sussel"));
        }


        [TestMethod]
        public void TestRemoveUser()
        {
            //Tests if the removing of the user, added in the mock db is successful

            Assert.IsTrue(um.RemoveUser(um.GetUser("radka")));
            Assert.IsNull(um.GetUser("radka"));
        }









        //Tests for the watchlist logic layer

        WatchlistManager wm = new WatchlistManager(new WatchlistDBMock());

        [TestMethod]
        public void TestGetWatchlist()
        {
            string[] pass = um.GetPass("1234");

            um.Register(new User(1, 1, "radolona", pass[1], "radka_piratka@gmail.com", "Rada", "1", pass[0]));

            //Checks if the the method successfully retvrieves the watchlist from the mock db 
            Assert.AreEqual(wm.GetWatchlist(um.GetUser("radolona")).Productions.Count, 2);
        }


        [TestMethod]
        public void TestContainsMovie()
        {
            //First check if the movie exists in the collection
            Assert.IsNotNull(cpm.GetCP(7));

            //Then check if it is added to a given user's personalised watchlist
            Assert.IsFalse(wm.ContainMovie(cpm.GetCP(7), um.GetUser("radka")));
        }

        [TestMethod]
        public void TestAddToWatchlist()
        {
            //Registering a new user
            string[] pass = um.GetPass("1234");

            um.Register(new User(1, 1, "radolona", pass[1], "radka_piratka@gmail.com", "Rada", "1", pass[0]));

            wm.GetWatchlist(um.GetUser("radolona"));

            //Checks of the method that adds the production was successfull
            Assert.IsTrue(wm.AddToWatchlist(um.GetUser("radolona"), cpm.GetCP(4)));

            //Testing if the production was successfully added to the list with the productions from the mock db
            Assert.AreEqual(um.GetUser("radolona").Watchlist.Productions[2], cpm.GetCP(4));
            Assert.AreEqual(um.GetUser("radolona").Watchlist.Productions.Count, 3);
            
        }










        FactoryClass fc = new FactoryClass(new MovieDBMock(), new TVShowDBMock(), new CPDBMock());

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<FormatException>(() => fc.CreateMovie(Convert.ToInt32("s"), "1", "", "2012-12-12", Convert.ToInt32("s"), Convert.ToInt32("s"), "dnk", null));
        }
    }
}