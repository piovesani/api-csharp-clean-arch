using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace ECommerce.Inflastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbConnection _connection;

    public UserRepository()
    {
        string connectionString = "Server=localhost;Database=ecommerce;" +
            "User ID=root;Password=;";
        _connection = new MySqlConnection(connectionString);
    }

    private void ExecuteNonQuery(MySqlCommand command)
    {
        try
        {
            _connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            _connection.Close();
        }
    }

    private MySqlDataReader ExecuteQuery(MySqlCommand command)
    {
        _connection.Open();
        return command.ExecuteReader();
    }

    private User MapUser(MySqlDataReader data)
    {
        return new User
        {
            Id = data.GetInt32("Id"),
            Name = VerifyItem(data, "Name") ? "" : data.GetString("Name"),
            Email = VerifyItem(data, "Email") ? "" : data.GetString("Email"),
            Gender = VerifyItem(data, "Gender") ? "" : data.GetString("Gender"),
            RG = VerifyItem(data, "RG") ? "" : data.GetString("RG"),
            CPF = VerifyItem(data, "CPF") ? "" : data.GetString("CPF"),
            MotherName = VerifyItem(data, "MotherName") ? "" : data.GetString("MotherName"),
            RegistrationStatus = VerifyItem(data, "RegistrationStatus") ? "" : data.GetString("RegistrationStatus"),
            RegistrationDate = VerifyItem(data, "RegistrationDate") ? default : data.GetDateTime("RegistrationDate")
        };
    }

    public List<User> GetUsersAsync()
    {
        List<User> users = new List<User>();
        string query = "SELECT * FROM Users";

        using (MySqlCommand command = new MySqlCommand(query, (MySqlConnection)_connection))
        using (MySqlDataReader data = ExecuteQuery(command))
        {
            while (data.Read())
            {
                users.Add(MapUser(data));

                //Contact contact = new Contact();
                //contact.Id = data.GetInt32("ContactId");
            }
        }

        return users;
    }

    public User GetByIdAsync(int id)
    {
        string query = "SELECT *, c.Id ContactId FROM Users u " +
            "LEFT JOIN Contacts c ON c.UserId = u.Id " +
            "WHERE u.Id = @Id";
        using (MySqlCommand command = new MySqlCommand(query, (MySqlConnection)_connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            using (MySqlDataReader data = ExecuteQuery(command))
            {
                if (data.Read())
                {
                    return MapUser(data);
                }
            }
        }

        return null;
    }

    public void InsertUserAsync(User user)
    {
        string query = "INSERT INTO Users " +
            "(Name, Email, Gender, RG, CPF, MotherName, RegistrationStatus, RegistrationDate) " +
            "VALUES " +
            "(@Name, @Email, @Gender, @RG, @CPF, @MotherName, @RegistrationStatus, @RegistrationDate);" +
            "SELECT LAST_INSERT_ID();";

        using (MySqlCommand command = new MySqlCommand(query, (MySqlConnection)_connection))
        {
            AddUserParameters(command, user);

            // Executa a inserção e obtém o último ID inserido
            _connection.Open();
            user.Id = Convert.ToInt32(command.ExecuteScalar());
            _connection.Close();
        }
    }

    public void UpdateUserAsync(User user)
    {
        string query = "UPDATE Users SET " +
            "Name = @Name, " +
            "Email = @Email, " +
            "Gender = @Gender, " +
            "RG = @RG, " +
            "CPF = @CPF, " +
            "MotherName = @MotherName, " +
            "RegistrationStatus = @RegistrationStatus WHERE Id = @Id";

        using (MySqlCommand command = new MySqlCommand(
            query, (MySqlConnection)_connection))
        {
            AddUserParameters(command, user);
            command.Parameters.AddWithValue("@Id", user.Id);
            ExecuteNonQuery(command);
        }
    }

    public void DeleteUserAsync(int id)
    {
        string query = "DELETE FROM Users WHERE Id = @Id";

        using (MySqlCommand command = new MySqlCommand(
            query, (MySqlConnection)_connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            ExecuteNonQuery(command);
        }
    }

    private void AddUserParameters(MySqlCommand command, User user)
    {
        command.Parameters.AddWithValue("@Name", user.Name);
        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@Gender", user.Gender);
        command.Parameters.AddWithValue("@RG", user.RG);
        command.Parameters.AddWithValue("@CPF", user.CPF);
        command.Parameters.AddWithValue("@MotherName", user.MotherName);
        command.Parameters.AddWithValue("@RegistrationStatus", user.RegistrationStatus);
        command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
    }

    public bool VerifyItem(MySqlDataReader data, string col)
    {
        return data.IsDBNull(data.GetOrdinal(col));
    }

    public bool EmailExists(string email, int userId)
    {
        bool exists = false;

        string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Id != @UserId";

        using (MySqlCommand command = new MySqlCommand(query, (MySqlConnection)_connection))
        {
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@UserId", userId);

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            exists = Convert.ToInt32(command.ExecuteScalar()) > 0;

            // Fechar a conexão após a execução
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        return exists;
    }
}
