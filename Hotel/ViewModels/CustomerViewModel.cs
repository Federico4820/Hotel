using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid CustomerId { get; set; }

        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required int Tell { get; set; }
    }
}
