using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeepMusic.Data;
using DeepMusic.Models;

namespace DeepMusic.Controllers
{
    public class TracksController : Controller
    {
        private readonly DeepMusicDbContext _context;

        public TracksController(DeepMusicDbContext context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tracks.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Track_ID,ArtistName,Album,Track,Time,Genre")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tracks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tracks);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = await _context.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return NotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Track_ID,ArtistName,Album,Track,Time,Genre")] Tracks tracks)
        {
            if (id != tracks.Track_ID)
            {
                return NotFound();
            }

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
            return View(tracks);
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
