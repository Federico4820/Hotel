using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; }

        [Required]
        public required int Number { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        [Range(1, 5000)]
        public double Price { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
