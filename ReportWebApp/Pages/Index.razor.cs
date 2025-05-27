using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.SqlClient;
using ReportWebApp.Data.Model;
using ReportWebApp.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static System.Net.WebRequestMethods;

namespace ReportWebApp.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public ClientService _clientService { get; set; }

        public List<Client> Clients { get; set; } = new();
        public List<ReportItem> ReportResults { get; set; }

        public InputModel InputModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            // Load clients from DB
            await LoadClientsAsync();
        }

        public async Task LoadClientsAsync()
        {
            // Clients = await _clientService.GetClientsAsync();

            Clients = new List<Client>
            {
                 new Client
                 {
                    Id = "101",
                    Name = "TCS",
                 },
                   new Client
                 {
                    Id = "102",
                    Name = "TechM",
                 },
                      new Client
                 {
                    Id = "103",
                    Name = "Infosys",
                 },

            };
        }

        public async Task GenerateReport()
        {
            ReportResults = new List<ReportItem>
            {
                new ReportItem
                {
                     DateSent = DateTime.Now,
                      Message =" Process Completed",
                       Status = "Success"
                },
                new ReportItem
                {
                     DateSent = DateTime.Now.AddDays(1),
                      Message =" Verification Pending",
                       Status = "Hold"
                }
            };
        }
        //{
        //    ReportResults = new List<ReportItem>();
        //    var connectionString = "YourConnectionStringHere";
        //    using var conn = new SqlConnection(connectionString);
        //    var cmd = new SqlCommand("SELECT Message, DateSent, Status FROM Reports WHERE ClientId = @ClientId AND ReportType = @Type AND DateSent BETWEEN @From AND @To", conn);

        //    cmd.Parameters.AddWithValue("@ClientId", InputModel.ClientId);
        //    cmd.Parameters.AddWithValue("@Type", InputModel.ReportType);
        //    cmd.Parameters.AddWithValue("@From", InputModel.FromDate);
        //    cmd.Parameters.AddWithValue("@To", InputModel.ToDate);

        //    await conn.OpenAsync();
        //    var reader = await cmd.ExecuteReaderAsync();

        //    while (await reader.ReadAsync())
        //    {
        //        ReportResults.Add(new ReportItem
        //        {
        //            Message = reader.GetString(0),
        //            DateSent = reader.GetDateTime(1),
        //            Status = reader.GetString(2)
        //        });
        //    }
        //}
    }
}

