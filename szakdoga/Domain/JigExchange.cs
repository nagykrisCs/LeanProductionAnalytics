using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeanProductionAnalytics.Domain
{
    public class JigExchange
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductionId { get; set; }
        public Production Production { get; set; } = null!;

        public ICollection<JigStep> JigSteps { get; set; } = new List<JigStep>();

        public string SetupId { get; set; } = null!;
    }
}
