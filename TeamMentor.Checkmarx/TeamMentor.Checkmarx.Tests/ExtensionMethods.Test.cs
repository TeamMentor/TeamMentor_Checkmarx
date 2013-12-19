using System;
using System.IO;
using System.Web.Routing;
using System.Web.WebPages;
using FluentSharp.CoreLib;
using NUnit.Framework;

namespace TeamMentor.Checkmarx.Tests
{
   
    [TestFixture]
    public class ExtensionMethods
    {
        #region const
        private const string ExpectedWsdl = "TeamMentor.Checkmarx.Versions._626.wsdl.xml";
        private const string ExpectedTestSoapMessages = "TeamMentor.Checkmarx.Tests.Resources.ExpectedSoapMethods.txt";
        private const string ExpectedTestWsdlResource = "TeamMentor.Checkmarx.Tests.Resources.ExpectedWsdl.xml";
        #endregion
        [Test]
        public void Find_Resource_File_AsXml()
        {
            string resource = ExpectedWsdl.GetXmlResponseFromFile();
            Assert.IsTrue(resource.notNull());
            Assert.IsTrue(resource.Length>0);
        }
        [Test]
        public void Resource_Not_Found_Should_Return_Empty()
        {
            var resource = "NonExistentFile".GetXmlResponseFromFile();
            Assert.IsTrue(resource.IsEmpty());
            Assert.IsTrue(true);
        }
        [Test]
        public void Pull_Xml_Messages_From_Wsdl_Match()
        {
            var wsdl = Utils.GetXmlResponseFromFile(ExpectedTestWsdlResource);
            var messages = Utils.GetXmlResponseFromFile(ExpectedTestSoapMessages);
            
            Assert.IsTrue(!String.IsNullOrEmpty(wsdl));
            Assert.IsTrue(!String.IsNullOrEmpty(messages));

            var pulledMessages = wsdl.GetWsdlMessages();
            Assert.AreEqual(pulledMessages.Trim(), messages.Trim());
        }
        [Test]
        public void Register_Route_For_Web_Service()
        {
            var servicePath = "~/Versions/626/CxWebService.asmx";
            var routeCollection = new RouteCollection();
            var route = routeCollection.MapWebServiceRoute("singleName", "temp", servicePath);
            Assert.IsTrue(!String.IsNullOrEmpty(route.Url));
        }
        [Test,
        ExpectedException(typeof(ArgumentException))]
        public void Register_Route_Url_Incorrect_Format()
        {
            var servicePath = "~/Versions/626/CxWebService.asmx";
            var routeCollection = new RouteCollection();
            var route = routeCollection.MapWebServiceRoute("singleName", "/temp", servicePath);
            
        }
        [Test,
        ExpectedException(typeof(ArgumentNullException))]
        public void Register_Routes_Rout_IsNull()
        {
            var servicePath = "~/Versions/626/CxWebService.asmx";
            RouteCollection routeCollection = null;
            var route = routeCollection.MapWebServiceRoute("singleName", "/temp", servicePath);

        }

        
    }
}
