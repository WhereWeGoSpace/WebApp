using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search;
using WhereWeGoAPI.Models.GrailTravel.SDK;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.UnitTests.Model
{
    [TestFixture]
    public class JourneyServiceTests
    {
        private IDetieClient _client;
        private IJourneyService _svc;
        private IList<Traveling> lsTraveling;

        [SetUp]
        public void SetUp()
        {
            lsTraveling = new List<Traveling> {
                new Traveling { From="aa", From_Code="a", To="bb", To_Code="b" },
                new Traveling { From="aa1", From_Code="aa", To="bb1", To_Code="bb" }
            };

            this._client = Substitute.For<IDetieClient>();
            this._svc = new JourneyService(this._client);

            this._svc.SetTravelings(lsTraveling);
        }

        [Test]
        public void JourneyService_Download_MethodExecutionIsSuccess()
        {
            //Arrange
            Traveling actual = null;
            List<SearchResponse> sd = new List<SearchResponse>();
            sd.Add(new SearchResponse { solutions = new List<Solution> { new Solution { sections = new List<Section>() { new Section { offers = new List<Offer> { new Offer { services = new List<Service> { new Service { booking_code = "123" } } } } } } } } });
            string str = JsonConvert.SerializeObject(sd);

            this._client.Search_Async(Arg.Any<AsyncKey>()).Returns(str);

            //Act
            actual = this._svc.GetRandomTraveling();

            //Assert
            this.lsTraveling.Should().Contain(actual);
        }

    }
}
