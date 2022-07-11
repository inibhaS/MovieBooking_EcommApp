using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class NewMovieVM
    {

        [Display(Name="Movie Name ")]
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Display(Name = "Movie Description ")]
        [Required(ErrorMessage = "Name is Required")]
        public string Description { get; set; }

        [Display(Name = "Movie Price in $ ")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

        [Display(Name = "Image URL ")]
        [Required(ErrorMessage = "Image URL is Required")]
        public string ImageURL { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }
        //Relationship


        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is Required")]
        public List<int> ActorIds { get; set; }


        //Cinema
        [Display(Name = "Select Cinema(s)")]
        [Required(ErrorMessage = "Cinema is Required")]
        public int CinemaId { get; set; }


        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Movie Producer is Required")]
        public int ProducerId { get; set; }
      





    }
}
