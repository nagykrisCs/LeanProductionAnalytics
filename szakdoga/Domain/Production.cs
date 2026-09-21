using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace LeanProductionAnalytics.Domain
{
    public class Production
    {
        // Add unique ID
        [Key]
        public Guid Id { get; set; }

        public string? JobId { get; set; }
        public string? ProductName { get; set; }
        public string? Operation { get; set; }
        public string? MachineId { get; set; }
        public string? OperatorId { get; set; }
        public string? Shift { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? ProcessingTime { get; set; }
        public int? QueueTime { get; set; }
        public int? RejectQuantity { get; set; }
        public bool? JigExchangeRequired { get; set; }
        public int? SetupTime { get; set; }
    }
}