using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Base;
namespace eTickets.Models
{
    public class Actor :IEntityBase
    {[Key]
        public int Id { get; set; }
         [Display(Name ="Profile Picture")]  
         [Required(ErrorMessage ="Profle Picture is Required")]
        public string ProfilePictureUrl { get; set; }
       
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Full Name must be between 3 & 50 characters")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is Required")]
        public string Bio { get; set; }
        //Relationship
        public List<Actor_Movies> Actors_Movies { get; set; }
    }
    
}
