using System.ComponentModel.DataAnnotations;

namespace Rapid_Rescue.DTO.RequestModel
{
    public class CreateContactQuery
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string? contactNumber { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string? messages { get; set; }

        public byte[] SubmittedAt { get; set; } = null!;
    }
}
