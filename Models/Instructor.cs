using System.ComponentModel.DataAnnotations;

namespace InstructorInformationsSystem.Models
{
    public class Instructor
    {
        [Required(ErrorMessage = "Instructor ID is required.")]
        [Display(Name = "Instructor ID")]
        public string InstructorID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Please enter a valid age (18-100).")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid contact number format.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Majorship is required.")]
        public string Majorship { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bachelor Degree is required.")]
        [Display(Name = "Bachelor Degree")]
        public string BachelorDegree { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Display(Name = "E-mail Address")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}