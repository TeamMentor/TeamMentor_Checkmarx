using NUnit.Framework;
using O2.DotNetWrappers.ExtensionMethods;

namespace CxWebInterface.Test
{
    [TestFixture]
    public class Test__WebMethod_CxPortalWebService
    {
        [Test]
        public void Login()
        {
            var proxy         = new CxPortalWebService_Wrapper();
            var loginResponse = proxy.Login(new Credentials() {User = "admin@cx", Pass = ">t1SMIjfQX"});            
            
            Assert.IsNotNull(loginResponse);
            
            var sessionId = loginResponse.SessionId;

            Assert.IsTrue(sessionId.valid());
        }
    }
}