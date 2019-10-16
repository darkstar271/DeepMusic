using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeepMusic.Data;
using DeepMusic.Models;
using DeepMusic.DTO;
// use #region "any name" and #end region to clean up code
//     #region method name
//     #endregion
namespace DeepMusic.Controllers
{
    public class TracksController : Controller
    {
        private readonly DeepMusicDbContext _context;

        public TracksController(DeepMusicDbContext context)
        {
            _context = context;
        }


        // Change made to use DTO – Data Transfer Objects.
        // https://gavilan.blog/2019/03/18/asp-net-core-2-2-data-transfer-objects-dtos-and-automapper/
        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var Tracks = _context.Tracks.Select(s => new TracksDTO()
            {
                Track_ID = s.Track_ID,
                ArtistName = s.ArtistName,
                Album = s.Album,
                Time = s.Time,
                Genre = s.Genre,
                //Genre_ID = s.Genre_ID,
                Track = s.Track,
                //  TracksTrack_ID = s.TracksTrack_ID
            }).ToListAsync();

            return View(await Tracks);

            //return View(await _context.Tracks.ToListAsync());
        }


        // Change made to use DTO – Data Transfer Objects.
        // GET: Tracks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracksDTO = _context.Tracks.Select(s => new TracksDTO()

            {
                Track_ID = s.Track_ID,
                ArtistName = s.ArtistName,
                Track = s.Track,
                Time = s.Time,
                Genre = s.Genre
            }).FirstOrDefault(m => m.Track_ID == id);

            if (tracksDTO == null)
            {
                return NotFound();
            }

            return View(tracksDTO);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Track_ID,ArtistName,Album,Track,Time,Genre")] TracksDTO tracksDTO)
        {


            var tracks = new Tracks()

            {
                Track_ID = tracksDTO.Track_ID,
                ArtistName = tracksDTO.ArtistName,
                Album = tracksDTO.Album,
                Track = tracksDTO.Track,
                Time = tracksDTO.Time,
                Genre = tracksDTO.Genre
            };
            if (ModelState.IsValid)
            {
                _context.Add(tracks);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tracksDTO);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracksDTO = _context.Tracks.Select(s => new TracksDTO()

            {
                Track_ID = s.Track_ID,
                ArtistName = s.ArtistName,
                Track = s.Track,
                Time = s.Time,
                Genre = s.Genre
            }).FirstOrDefault(m => m.Track_ID == id);

            if (tracksDTO == null)
            {
                return NotFound();
            }
            return View(tracksDTO);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Track_ID,ArtistName,Album,Track,Time,Genre")] TracksDTO tracksDTO)
        {
            if (id != tracksDTO.Track_ID)
            {
                return NotFound();
            }

            var tracks = new Tracks()

            {
                Track_ID = tracksDTO.Track_ID,
                ArtistName = tracksDTO.ArtistName,
                Album = tracksDTO.Album,
                Track = tracksDTO.Track,
                Time = tracksDTO.Time,
                Genre = tracksDTO.Genre
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tracks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TracksExists(tracks.Track_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tracksDTO);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = await _context.Tracks
                .FirstOrDefaultAsync(m => m.Track_ID == id);
            if (tracks == null)
            {
                return NotFound();
            }

            return View(tracks);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tracks = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(tracks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TracksExists(int id)
        {
            return _context.Tracks.Any(e => e.Track_ID == id);
        }
    }
}
