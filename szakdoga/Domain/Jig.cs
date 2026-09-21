using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace LeanProductionAnalytics.Domain
{
    public class Jig
    {
        [Key]
        public Guid Id { get; set; }

        public string SetupId { get; set; }
        public string JobId { get; set; }
        public string MachineId { get; set; }
        public string OperatorId { get; set; }
        public string Step { get; set; }
        public int Duration { get; set; }
    }
}
