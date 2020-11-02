using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLRSIntroductoryWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Required]
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }

        [Required]
        [ForeignKey("UserTitle")]
        public int UserTitleId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive
        {
            get; set;
        }
    }
}
