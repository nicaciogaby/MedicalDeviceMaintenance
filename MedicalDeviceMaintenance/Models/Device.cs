using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceMaintenance.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? SerialNumber { get; set; }
        public string? Location { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}