using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceMaintenance.Models
{
    public class MaintenanceAction
    {
        public int Id { get; set; }

        [Required]
        public string ActionTaken { get; set; } = string.Empty;

        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        // Link to Incident
        public int IncidentId { get; set; }
        public Incident? Incident { get; set; }
    }
}