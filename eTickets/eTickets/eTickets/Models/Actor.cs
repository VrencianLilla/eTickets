using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string Bio { get; set; }
        [Display(Name = "Bio")]

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
