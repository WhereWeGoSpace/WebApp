using System.Threading.Tasks;
using NUnit.Framework;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.UnitTests.Model
{
    [TestFixture]
    public class IssueTicketServiceTests
    {
        private IIssueTicketService _svc;

        [SetUp]
        public void SetUp()
        {
            this._svc = new IssueTicketService();
        }

        [Test]
        public async Task IssueTicketService_Download_MethodExecutionIsSuccess()
        {
            //Arrange


            //Act


            //Assert
        }
    }
}
