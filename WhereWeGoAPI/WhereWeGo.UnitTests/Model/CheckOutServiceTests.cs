using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.UnitTests.Model
{
    [TestFixture]
    public class CheckOutServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _svc = new CheckOutService();
        }

        private ICheckOutService _svc;

        [Test]
        public async Task CheckOutService_BookTraveling_MethodExecutionIsSuccess()
        {
            //Arrange
            BookingResponse expect = new BookingResponse(),
                actual = null;
            var bookingInfo = new Booking
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
                Passengers = new List<Passenger>
                {
                    new Passenger
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
            _svc.BookTraveling(bookingInfo);

            //Asert
            actual.Should().Be(actual);
        }

        [Test]
        public async Task CheckOutService_Pay_MethodExecutionIsSuccess()
        {
            //Arrange
            ConfirmResponse expect = new ConfirmResponse(),
                actual = null;

            var bookingId = Guid.NewGuid().ToString();
            var payRequest = new ConfirmRequest
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
            _svc.Pay(bookingId, payRequest);

            //Assert
            expect.Should().Be(actual);
        }
    }
}