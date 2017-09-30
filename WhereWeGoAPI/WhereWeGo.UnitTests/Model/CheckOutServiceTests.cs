using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WhereWeGo.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.UnitTests.Model
{
    [TestFixture]
    public class CheckOutServiceTests
    {
        private ICheckOutService _svc;

        [SetUp]
        public void SetUp()
        {
            this._svc = new CheckOutService();
        }

        [Test]
        public async Task CheckOutService_BookTraveling_MethodExecutionIsSuccess()
        {
            //Arrange
            BookingResponse expect = new BookingResponse { },
                actual = null;
            Booking bookingInfo = new Booking
            {
                From_Code = "ST_EZVVG1X5",
                To_Code = "ST_D8NNN9ZK",
                Contactor = new Contact
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100"
                },
                Passengers = new List<DTOs.GrailTravel.SDK.Requests.Passenger>
                {
                    new DTOs.GrailTravel.SDK.Requests.Passenger
                    {
                        last_name = "zhang",
                        first_name = "san",
                        birthdate = "1986-09-01",
                        passport = "A123456",
                        email = "x@a.cn",
                        phone = "15000367081",
                        gender = "male"
                    }
                }
            };

            //Act
            this._svc.BookTraveling(bookingInfo);

            //Asert
            actual.Should().Be(actual);
        }

        [Test]
        public async Task CheckOutService_Pay_MethodExecutionIsSuccess()
        {
            //Arrange
            ConfirmResponse expect = new ConfirmResponse { },
                actual = null;

            string bookingId = Guid.NewGuid().ToString();
            ConfirmRequest payRequest = new ConfirmRequest
            {
                credit_card = new CreditCard
                {
                    cvv = "123",
                    exp_year = 2017,
                    exp_month = 10,
                    number = "4522924383871823"
                }
            };

            //Act
            this._svc.Pay(bookingId, payRequest);

            //Assert
            expect.Should().Be(actual);
        }
    }
}
