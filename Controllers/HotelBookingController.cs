using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking_API.Context;
using HotelBooking_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if(booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            } else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if(bookingInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                bookingInDb = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();
            return new JsonResult(Ok(result));
        }


        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);
            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);
            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Bookings.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

    }
}
