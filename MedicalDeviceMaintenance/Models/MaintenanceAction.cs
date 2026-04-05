using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDeviceMaintenance.Models
{
    public class MaintenanceAction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Action Date")]
        public DateTime ActionDate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Technician Name")]
        public string TechnicianName { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Foreign key to Incident (not Device directly)
        [Display(Name = "Incident")]
        public int IncidentId { get; set; }

        [ForeignKey("IncidentId")]
        public Incident? Incident { get; set; }
    }
}