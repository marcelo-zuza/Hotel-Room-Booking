using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking_API.Context
{
    public class ApiContext: DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}