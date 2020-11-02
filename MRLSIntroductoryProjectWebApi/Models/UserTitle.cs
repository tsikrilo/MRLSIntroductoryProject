using System.ComponentModel.DataAnnotations;

namespace MLRSIntroductoryWebApi.Models
{
    public class UserTitle
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
