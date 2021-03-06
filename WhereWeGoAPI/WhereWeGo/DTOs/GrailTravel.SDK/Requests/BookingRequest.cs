﻿using System.Collections.Generic;
using Newtonsoft.Json;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests
{
    public class BookingRequest : RequestBase
    {
        /// <summary>
        /// 订票联系人，详见Contact联系人信息表格
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public Contact contact { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        /// <value>
        /// The passengers.
        /// </value>
        public IList<Passenger> passengers { get; set; }
        /// <summary>
        /// Segments，行程中的不同车型
        /// </summary>
        /// <value>
        /// The sections.
        /// </value>
        public IList<string> sections { get; set; }
        /// <summary>
        /// 是否订座，true or false
        /// </summary>
        /// <value>
        ///   <c>true</c> if [seat reserved]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("seat_reserved")]
        public bool seat_reserved { get; set; }
    }

    public class Contact
    {
        /// <summary>
        /// 名字
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string phone { get; set; }
        /// <summary>
        /// 邮寄地址
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string address { get; set; }
        /// <summary>
        /// the postcode.
        /// </summary>
        /// <value>
        /// The postcode.
        /// </value>
        public string postcode { get; set; }
    }
}