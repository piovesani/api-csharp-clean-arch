namespace ECommerce.Domain.Entities
{
    public class DeliveryAddress
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string AddressName { get; private set; }
        public string PostalCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string Address { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public User? User { get; private set; }

        // Construtor para garantir que o objeto seja criado com dados válidos
        public DeliveryAddress(string addressName, string postalCode, string state, string city,
            string neighborhood, string address, string number, string complement, User? user = null)
        {
            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(addressName)) throw new ArgumentException("Address name is required", nameof(addressName));
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Postal code is required", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("State is required", nameof(state));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required", nameof(city));
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address is required", nameof(address));
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Number is required", nameof(number));

            AddressName = addressName;
            PostalCode = postalCode;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Address = address;
            Number = number;
            Complement = complement;
            User = user;
        }

        // Método para atualizar o endereço (caso necessário)
        public void UpdateAddress(string address, string number, string complement)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address cannot be empty", nameof(address));
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Number cannot be empty", nameof(number));

            Address = address;
            Number = number;
            Complement = complement;
        }
    }
}
