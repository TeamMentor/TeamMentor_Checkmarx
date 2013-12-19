
using System;
using System.Web;
using System.Web.Routing;
using FluentSharp.CoreLib;
using NUnit.Framework;
using TypeMock;

namespace TeamMentor.Checkmarx.Tests
{
    [TestFixture]
    public class Router
    {
        private static readonly string ExpectedCheckmarx7Wsdl =
            "TeamMentor.Checkmarx.Tests.Resources.ExpectedCheckmarx712Soap.txt";
        private static readonly string ExpectedCheckmarx629Wsdl =
           "TeamMentor.Checkmarx.Tests.Resources.ExpectedCheckmarx629Soap.txt";
        [Test]
        public void Routing_To_Checkmarx712()
        {
            RouteTable.Routes.Clear();
            var expectedWsdl = Utils.GetXmlResponseFromFile(ExpectedCheckmarx7Wsdl);
            MockManager.Init();
            using (var record = new RecordExpectations())
                record.ExpectAndReturn(Web_ExtensionMethods_Http_Requests.GET("URL"), expectedWsdl);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
            Assert.IsTrue(RouteTable.Routes.count() ==6);
            MockManager.Verify();
        }


        [Test]
        public void Routing_To_Checkmarx629()
        {
            RouteTable.Routes.Clear();
            var expectedWsdl = Utils.GetXmlResponseFromFile(ExpectedCheckmarx629Wsdl);
            MockManager.Init();
            using (var record = new RecordExpectations())
                record.ExpectAndReturn(Web_ExtensionMethods_Http_Requests.GET("URL"), expectedWsdl);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           // Assert.IsTrue(RouteTable.Routes.count() == 6);
            MockManager.Verify();
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Routing_To_BadRequest()
        {
            var expectedWsdl = Utils.GetXmlResponseFromFile(ExpectedCheckmarx7Wsdl);
            MockManager.Init();
            using (var record = new RecordExpectations())
                record.ExpectAndReturn(Web_ExtensionMethods_Http_Requests.GET("URL"), null);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
            MockManager.Verify();
        }
    }
}
