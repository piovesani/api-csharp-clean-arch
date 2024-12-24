using ECommerce.Domain.Validation;

namespace ECommerce.Domain.Entities
{
    public class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public string MotherName { get; private set; }
        public string RegistrationStatus { get; private set; }
        public DateTimeOffset RegistrationDate { get; private set; }

        // Relacionamento 1-1
        public Contact? Contact { get; private set; }

        // Composição
        public ICollection<DeliveryAddress>? 
            DeliveryAddresses { get; private set; }
        public ICollection<Department>? 
            Departments { get; private set; }

        public User(
            string name, 
            string email, 
            string gender, 
            string rg, 
            string cpf,
            string motherName, 
            string registrationStatus, 
            DateTimeOffset registrationDate
            )
        {
            ValidateName(name);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email não pode ser vázio", nameof(email));
            }

            Name = name;
            Email = email;
            Gender = gender;
            RG = rg;
            CPF = cpf;
            MotherName = motherName;
            RegistrationStatus = registrationStatus;
            RegistrationDate = registrationDate;

            DeliveryAddresses = new List<DeliveryAddress>();
            Departments = new List<Department>();
        }

        // Métodos de comportamento relacionados ao usuário
        public void UpdateContact(Contact contact)
        {
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public void AddDeliveryAddress(DeliveryAddress address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            DeliveryAddresses?.Add(address);
        }

        public void AddDepartment(Department department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            Departments?.Add(department);
        }

        private void ValidateName(string name)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(name),
                "Nome não pode ser vazio ou nulo."
                );

            DomainExceptionValidation.When(
                name.Length < 3,
                "Nome deve ter no mínimo 3 caracteres."
                );

            DomainExceptionValidation.When(
                name.Length > 50,
                "Nome não pode exceder 50 caracteres."
                );
        }
    }
}
