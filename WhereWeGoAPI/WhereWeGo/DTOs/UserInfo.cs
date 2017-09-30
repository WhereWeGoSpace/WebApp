namespace WhereWeGo.DTOs
{
    public class UserInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            UserInfo target = obj as UserInfo;
            if (target == null) return false;

            return this.FirstName.Equals(target.FirstName) &&
                this.LastName.Equals(target.LastName) &&
                this.Email.Equals(target.Email) &&
                this.Address.Equals(target.Address) &&
                this.PostCode.Equals(target.PostCode) &&
                this.City.Equals(target.City) &&
                this.Country.Equals(target.Country);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() |
                this.LastName.GetHashCode() |
                this.Email.GetHashCode() |
                this.Address.GetHashCode() |
                this.PostCode.GetHashCode() |
                this.City.GetHashCode() |
                this.Country.GetHashCode();
        }
    }
}