using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDeviceMaintenance.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Incident Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Reported")]
        public DateTime DateReported { get; set; }

        [Required]
        [StringLength(20)]
        public string Severity { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        [Display(Name = "Device")]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public Device? Device { get; set; }

        // Navigation property — one Incident has many MaintenanceActions
        public ICollection<MaintenanceAction>? MaintenanceActions { get; set; }
    }
}