using System;
using CheckMarxMapping.Test;
using NUnit.Framework;

namespace CxWebInterface.Test
{
    [TestFixture]
    class Configuration: Base
    {
        [Test]
        public void Load_Secret_Data()
        {
            var configuration = new CXConfiguration();
            Assert.IsTrue(String.IsNullOrEmpty(configuration.CheckMarx_WebService_EndPoint));
            Assert.IsTrue(String.IsNullOrEmpty(configuration.TeamMentor_Vulnerabilities_Server_URL));
            configuration =configuration.secretData_Load();
            Assert.IsTrue(!String.IsNullOrEmpty(configuration.CheckMarx_WebService_EndPoint));
            Assert.IsTrue(!String.IsNullOrEmpty(configuration.TeamMentor_Vulnerabilities_Server_URL));

        }

        [Test]
        public void Can_Read_Configuration_Values()
        {
           var configuration = new CXConfiguration();
           Assert.IsTrue(!String.IsNullOrEmpty(configuration.secretData_Load().CheckMarx_WebService_EndPoint));
           Assert.IsTrue(!String.IsNullOrEmpty(configuration.secretData_Load().TeamMentor_Vulnerabilities_Server_URL));
        }
    }
}
