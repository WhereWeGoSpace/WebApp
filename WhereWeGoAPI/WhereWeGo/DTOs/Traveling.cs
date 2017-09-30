using System;

namespace WhereWeGoAPI.DTOs
{
    public class Traveling
    {
        public string From { get; set; }

        public string From_Code { get; set; }

        public string To { get; set; }

        public string To_Code { get; set; }

        public string Booking_Code { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            Traveling target = obj as Traveling;
            if (target == null) return false;

            return this.From.Equals(target.From) &&
                this.From_Code.Equals(target.From_Code) &&
                this.To.Equals(target.To) &&
                this.To_Code.Equals(target.To_Code) &&
                this.Booking_Code.Equals(target.Booking_Code) &&
                this.Date.Equals(target.Date) &&
                this.Price.Equals(target.Price);
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode() |
                this.From_Code.GetHashCode() |
                this.To.GetHashCode() |
                this.To_Code.GetHashCode() |
                this.Booking_Code.GetHashCode() |
                this.Date.GetHashCode() |
                this.Price.GetHashCode();
        }
    }
}