using System.ComponentModel.DataAnnotations;

namespace PersonsApp.Entities
{
    public class PersonEntity
    {
        [Required(ErrorMessage = "El DNI es requerido")]
        [StringLength(13, ErrorMessage = "El DNI debe tener 13 dígitos.", MinimumLength = 13)]
        public string DNI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

    }
}