namespace FloralAppFE.Ecommerce.Models
{
    public class RegisterCustomerViewModel
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; } = null!;
        public string? Photo { get; set; }
    }
}
