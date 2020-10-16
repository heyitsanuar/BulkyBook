using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulkyBook.DataAccess.Data;
using BulkyBook.Models;
using Microsoft.AspNet.OData;

namespace BulkyBook.Areas.Customer.Controllers
{
    public class SongsController : ODataController
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.Where(s => s.Id == id).SingleOrDefaultAsync();

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }
    }
}
