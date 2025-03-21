using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }

        public Guid CustumerId { get; set; }
        [ForeignKey("CustumerId")]
        public Customer customer { get; set; }

        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
