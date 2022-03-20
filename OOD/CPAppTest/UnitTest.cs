using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesAndSeriesApplication;


namespace CPAppTest
{
    [TestClass]
    public class UnitTest
    {

        CPManager cpmanager = new CPManager();
        UserManager um = new UserManager();

        [TestMethod]
        public void CheckValidDate()
        {
            Assert.IsFalse(cpmanager.CheckDate("201221-2-13"));
        }
    

    }
}