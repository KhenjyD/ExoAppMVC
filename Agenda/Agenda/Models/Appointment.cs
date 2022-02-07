using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    public class Appointment
    {
        [Key]
        public int idAppointment { get; set; }

        [Required]
        public DateTime dateHour { get; set; }

        [Required]
        public string subject { get; set; }

        [ForeignKey("Broker")]
        public int idBroker { get; set; }

        [ForeignKey("Customer")]
        public int idCustomer { get; set; }
    }
}
