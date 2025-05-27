using Microsoft.Data.SqlClient;
using ReportWebApp.Data.Model;
using System.Data;

namespace ReportWebApp.Services
{
    public class ClientService
    {
        private readonly string _connectionString;

        public ClientService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var clients = new List<Client>();

            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT ClientId, ClientName FROM Clients", conn);

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clients.Add(new Client
                {
                    Id = reader["ClientId"].ToString(),
                    Name = reader["ClientName"].ToString()
                });
            }

            return clients;
        }
    }

}