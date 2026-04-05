using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceMaintenance.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public ICollection<Incident>? Incidents { get; set; }
    }
}