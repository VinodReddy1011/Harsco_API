using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]

        public DateTime Dob { get; set; }


        [Required]
        public string? Gender { get; set; }


        [Required]
        public string? Education { get; set; }

        [Required]
        public string? Company { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public int Package { get; set; }
        
       
    }
}
