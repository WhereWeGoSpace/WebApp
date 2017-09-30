using System.Threading.Tasks;
using NUnit.Framework;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.UnitTests.Model
{
    [TestFixture]
    public class JourneyServiceTests
    {
        private IJourneyService _svc;

        [SetUp]
        public void SetUp()
        {
            this._svc = new JourneyService();
        }

        [Test]
        public async Task JourneyService_Download_MethodExecutionIsSuccess()
        {
            //Arrange


            //Act

            //Assert
        }

    }
}
