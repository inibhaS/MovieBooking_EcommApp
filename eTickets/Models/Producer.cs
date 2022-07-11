using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture Is Required")]
        public string ProfilePictureUrl { get; set; }


        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Full Name Is Required")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 char")]
        public string FullName { get; set; }


        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio Is Required")]
        public string Bio { get; set; }


        //Relationship

        public List<Movie> Movies { get; set; }

    }
}
