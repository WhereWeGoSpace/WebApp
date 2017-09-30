namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Passenger
    {
        /// <summary>
        /// 姓，拼音
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string last_name { get; set; }
        /// <summary>
        /// 名，拼音
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string first_name { get; set; }
        /// <summary>
        /// 生日，格式为yyyy-MM-dd
        /// </summary>
        /// <value>
        /// The birthdate.
        /// </value>
        public string birthdate { get; set; }
        /// <summary>
        /// 护照号
        /// </summary>
        /// <value>
        /// The passport.
        /// </value>
        public string passport { get; set; }
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
        /// male or female
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string gender { get; set; }
    }
}