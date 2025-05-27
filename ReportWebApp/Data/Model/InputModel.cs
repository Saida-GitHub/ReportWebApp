using System.ComponentModel.DataAnnotations;

namespace ReportWebApp.Data.Model
{
    public class InputModel
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public string ReportType { get; set; }
    }
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ReportItem
    {
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public string Status { get; set; }
    }
}
