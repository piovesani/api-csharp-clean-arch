namespace ECommerce.Domain.Entities
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<User> Users { get; private set; } 
        public Department(string name, ICollection<User> users = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Department name is required", nameof(name));

            Name = name;
            Users = users?.ToList().AsReadOnly() ?? new List<User>().AsReadOnly(); // Se nenhum usuário for fornecido, cria uma lista vazia
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user), "User cannot be null");

            var usersList = Users.ToList();
            usersList.Add(user);
            Users = usersList.AsReadOnly(); 
        }
    }
}
