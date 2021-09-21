using Practitioner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Application.CQRS.ViewModels
{
    public class DoctorInsightViewModel
    {
        public Guid CardId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public List<string> Insight { get; set; }

        public DoctorInsightViewModel(DoctorInsight insight)
        {
            CardId = insight.CardId;
            Insight = insight.Insights.Select(x => x.Insight).ToList(); 
        }
    }
}
