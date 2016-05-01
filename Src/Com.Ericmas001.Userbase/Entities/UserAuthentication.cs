using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Ericmas001.Userbase.Entities
{
    [Table("UserAuthentications")]
    public class UserAuthentication
    {
        [Key]
        [ForeignKey("User")]
        public int IdUser { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string RecoveryEmail { get; set; }

        public virtual User User { get; set; }
    }
}
