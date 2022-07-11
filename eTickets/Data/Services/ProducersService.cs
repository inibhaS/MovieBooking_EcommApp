﻿using eTickets.Data.Base;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {//inject app db context
        public ProducersService(AppDbContext context):base(context)        {

        }
    }
}