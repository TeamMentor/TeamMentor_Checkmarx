using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using O2.DotNetWrappers.ExtensionMethods;

namespace CxWebInterface.Test
{
    [TestFixture]
    class Test_CxOfflineMode
    {
        [Test(Description = "Simulates the CxPortalWebService Login method")]
        public void Login()
        {
            var loginData = CxOfflineMode.Login(null);
            Assert.IsNotNull(loginData);
        }

        [Test(Description = "Returns the folder containing the offline files")]
        public void Util_OfflineDataFolder()
        {
            var offlineDataFolder = CxOfflineMode.Util_OfflineDataFolder();
            var files             = offlineDataFolder.files();            
            var file              = offlineDataFolder.pathCombine("Login.xml");
            Assert.IsTrue    (offlineDataFolder.dirExists());
            Assert.IsNotEmpty(files);
            Assert.IsTrue    (file.fileExists());
        }

        [Test(Description = "Returns an object from the offline serialized file")]
        public void FileContentsAsObject()
        {
            var file = "Login.xml";
            var cxWSResponseLoginData = CxOfflineMode.FileContentsAsObject<CxWSResponseLoginData>(file);
            Assert.IsNotNull(cxWSResponseLoginData);
            //var tempFile = "aaa".tempFile();
            //cxWSResponseLoginData.saveAs(tempFile);
            //Assert.AreEqual ("",tempFile.info());
            Assert.IsInstanceOf<CxWSResponseLoginData >(cxWSResponseLoginData);
            Assert.IsNotNull(cxWSResponseLoginData.SessionId);
            Assert.AreEqual (cxWSResponseLoginData.FamilyName,"admin");
            Assert.AreEqual (cxWSResponseLoginData.IsAllowedToManageSp,true);
            
        }
    }
}
