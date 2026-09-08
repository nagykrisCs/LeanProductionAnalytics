using System.Xml;

namespace szakdoga.Domain
{
    public class Jig
    {
        public string? SetupId { get; set; }
        public string? JobId { get; set; }
        public string? MachineId { get; set; }
        public string? OperatorId { get; set; }
        public string? Step { get; set; }
        public int? Duration { get; set; }
    }
}
