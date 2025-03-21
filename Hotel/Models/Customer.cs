using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Customer
    {
        //definiamo le proprietà che rappresentano le colonne della tabella sul database
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [StringLength(20)]
        public required string Surname { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required int Tell { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
