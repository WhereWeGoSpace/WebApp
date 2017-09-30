using System;

namespace WhereWeGo.DTOs
{
    public class Traveling
    {
        public string From { get; set; }

        public string To { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            Traveling target = obj as Traveling;
            if (target == null) return false;

            return this.From.Equals(target.From) &&
                this.To.Equals(target.To) &&
                this.Date.Equals(target.Date) &&
                this.Price.Equals(target.Price);
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode() |
                this.To.GetHashCode() |
                this.Date.GetHashCode() |
                this.Price.GetHashCode();
        }
    }
}