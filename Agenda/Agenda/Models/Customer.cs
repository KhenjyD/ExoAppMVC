using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Customer
    {
        [Key]
        public int idCustomer { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = " Numéro trop court (Entrez numéro à 10 chiffres)")]
        [MaxLength(10, ErrorMessage = " Numéro trop long (Entrez numéro à 10 chiffres)")]
        public string phoneNumber { get; set; }

        [Required]
        public int budget { get; set; }
    }
}
