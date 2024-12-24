namespace ECommerce.Domain.Entities
{
    public class Contact
    {
        public int Id { get; private set; }
        public string? Phone { get; private set; }
        public string? CellPhone { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        public Contact(string? phone, string? cellPhone, User user)
        {
            Phone = phone;
            CellPhone = cellPhone;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
