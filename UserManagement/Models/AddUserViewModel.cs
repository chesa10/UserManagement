using System.ComponentModel.DataAnnotations;
using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Frontend.Models
{
    public class AddUserViewModel
    {
        public IEnumerable<Group>? Groups { get; set; }
        public IEnumerable<int> GroupIds { get; set; }

        [StringLength(100)]
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(100)]
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(12)]
        public string ContactNumber { get; set; }
    }
}
