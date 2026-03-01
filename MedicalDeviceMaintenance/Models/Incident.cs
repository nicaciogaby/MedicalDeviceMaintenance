using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceMaintenance.Models
{
    public enum IncidentStatus
    {
        Open = 0,
        InProgress = 1,
        Closed = 2
    }

    public class Incident
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public IncidentStatus Status { get; set; } = IncidentStatus.Open;

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        
        public int? DeviceId { get; set; }
        public Device? Device { get; set; }
    }
}