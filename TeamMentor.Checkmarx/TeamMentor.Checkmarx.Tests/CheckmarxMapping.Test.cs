using FluentSharp.CoreLib;
using NUnit.Framework;
namespace TeamMentor.Checkmarx.Tests
{
    [TestFixture]
    public   class CheckmarxMapping
    {
        [Test]
        public  void XmlMapping_IsLoading_Correctly()
        {
            var data = CxTeamMentor_Mappings.Tm_QueryId_Mappings;
            Assert.IsTrue(data.notNull() && data.Count>0);
        }
        [Test]
        public  void XmlMapping_Fully_Loaded()
        {
            var data = CxTeamMentor_Mappings.Tm_QueryId_Mappings;
            Assert.IsTrue(data.notNull() && data.Count>0);
            Assert.IsTrue(data.Count ==114);
            data.toList().ForEach(x => Assert.IsTrue(x.Key > 10000)); 
        }
    }
}
