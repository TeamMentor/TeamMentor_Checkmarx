using System;
using System.Web;
using Checkmarx712;
using FluentSharp.CoreLib;
using NUnit.Framework;
using TypeMock;

namespace TeamMentor.Checkmarx.Tests
{
    [TestFixture]
    public class CxResolver
    {
        private static readonly string AuditUrl       = @"http://localhost/CxWebInterface/Audit/CxAuditWebService.asmx";
        private static readonly string PortalUrl      = @"http://localhost/CxWebInterface/Portal/CxWebService.asmx";
        private static readonly string VsUrl          = @"http://localhost/CxWebInterface/Portal/CxVSWebService.asmx";
        private static readonly string EclipseUrl     = @"http://localhost/CxWebInterface/Portal/CxEclipseWebService.asmx";
        private static readonly string CliUrl         = @"http://localhost/CxWebInterface/Cli/CxCliService.asmx";

        [SetUp]
        public void SetUp()
        {
         
        }

        [Test]
        public void Test_Get_Audit_EndPoint()
        {
            MockManager.Init(); 
            var mbMock = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mbMock.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse(AuditUrl));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);
             
            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("","http://www.localhost.cpm",""));
            
            var proxy = new CxWSResolver();
             var url =proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

            Assert.IsTrue(url.notNull());
            Assert.IsTrue(url.isUri());

        }

        [Test]
        public void Test_Get_Portal_EndPoint()
        {
            MockManager.Init();
            var mockProxy = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mockProxy.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse(PortalUrl));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);

            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("", "http://www.localhost.cpm", ""));

            var proxy = new CxWSResolver();
            var url = proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

            Assert.IsTrue(url.notNull());
            Assert.IsTrue(url.isUri());

        }

        [Test]
        public void Test_Get_VS_EndPoint()
        {
            MockManager.Init();
            var mbMock = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mbMock.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse(VsUrl));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);

            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("", "http://www.localhost.cpm", ""));

            var proxy = new CxWSResolver();
            var url = proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

            Assert.IsTrue(url.notNull());
            Assert.IsTrue(url.isUri());

        }
        [Test]
        public void Test_Get_Eclipse_EndPoint()
        {
            MockManager.Init();
            var mbMock = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mbMock.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse(EclipseUrl));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);

            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("", "http://www.localhost.cpm", ""));

            var proxy = new CxWSResolver();
            var url = proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

            Assert.IsTrue(url.notNull());
            Assert.IsTrue(url.isUri());

        }

        [Test]
        public void Test_Get_Cli_EndPoint()
        {
            MockManager.Init();
            var mbMock = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mbMock.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse(CliUrl));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);

            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("", "http://www.localhost.cpm", ""));

            var proxy = new CxWSResolver();
            var url = proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

            Assert.IsTrue(url.notNull());
            Assert.IsTrue(url.isUri());

        }

        [Test]
        [ExpectedException (typeof(ArgumentException))]
        public void Test_EndPoint_NotValid()
        {
            MockManager.Init();
            var mbMock = MockManager.Mock(typeof(CxWSResolver_Proxy));
            mbMock.ExpectAndReturn("GetWebServiceUrl", GetServiceResponse("local"));
            var mockedContext = MockManager.MockObject<HttpContext>(Constructor.Mocked);

            Mock httpContextMock = MockManager.Mock<HttpContext>(Constructor.Mocked);

            httpContextMock.ExpectGetAlways("Current", mockedContext.MockedInstance);
            mockedContext.ExpectGetAlways("Request", new HttpRequest("", "http://www.localhost.cpm", ""));

            var proxy = new CxWSResolver();
            var url = proxy.GetWebServiceUrl(CxClientType.Audit, 1).ServiceURL;
            MockManager.Verify();

        

        }

        #region

        private CxWSResponseDiscovery GetServiceResponse(string Url)
        {
            var discovery = new CxWSResponseDiscovery();
            discovery.IsSuccesfull = true;
            discovery.ServiceURL = Url;
            return discovery;
        }

        #endregion
    }
}
