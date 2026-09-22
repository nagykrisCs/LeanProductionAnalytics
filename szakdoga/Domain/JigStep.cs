using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace LeanProductionAnalytics.Domain
{
    public class JigStep
    {
        [Key]
        public Guid Id { get; set; }

        public Guid JigExchangeId { get; set; }
        public JigExchange JigExchange { get; set; } = null!;

        public int Sequence { get; set; }
        public string Step { get; set; } = null!;
        public int Duration { get; set; }
    }
}
