namespace MedicalDeviceMaintenance.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string? Email { get; set; }
        public List<string> Roles { get; set; } = new();
    }

    public class EditRoleViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string CurrentRole { get; set; } = string.Empty;
        public List<string?> AllRoles { get; set; } = new();
    }
}