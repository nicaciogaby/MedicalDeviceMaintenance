using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceMaintenance.Models
{
    public class MaintenanceAction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; } = string.Empty;

        [Display(Name = "Action Date")]
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        public int IncidentId { get; set; }
        public Incident? Incident { get; set; }
    }
}