using System.ComponentModel.DataAnnotations;

namespace BusinessIntelligenceDashboard.Models
{
    // This Class is for the User
    public class UserModel
    {
        //Data Members
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string organization { get; set; }

        public UserModel(){ }
    }
}