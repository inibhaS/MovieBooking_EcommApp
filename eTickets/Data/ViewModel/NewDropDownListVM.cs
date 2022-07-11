﻿using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModel
{
    public class NewDropDownListVM
    {
       //constructor
        public NewDropDownListVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();


        }
        //property
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }

    }
}
