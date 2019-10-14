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

namespace DeepMusic.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly DeepMusicDbContext _context;

        public ArtistsController(DeepMusicDbContext context)
        {
            _context = context;
        }

        // GET: Artists
        // Change made to use DTO – Data Transfer Objects.
        // https://gavilan.blog/2019/03/18/asp-net-core-2-2-data-transfer-objects-dtos-and-automapper/
        public async Task<IActionResult> Index()
        {
            var Artist = _context.Artist.Select(s => new ArtistDTO()
            {
                Artist_ID = s.Artist_ID,
                ArtistName = s.ArtistName,
                Album = s.Album,
                AlbumCoverPath = s.AlbumCoverPath,
                Genre = s.Genre,
                //  TracksTrack_ID = s.TracksTrack_ID
            }).ToListAsync();
            return View(await Artist);
        }


        // Change made to use DTO – Data Transfer Objects.
        // GET: Artists/Details/5
        // for some of the method's the async has to be removed, it's not best practices but for this it works. 
        public IActionResult Details(int? id) // async removed
        {
            if (id == null)
            {
                return NotFound();
            }

            // When writing this the braced must be put at end of method
            var artistDTO = _context.Artist.Select(s => new ArtistDTO()
            {

                Artist_ID = s.Artist_ID,
                ArtistName = s.ArtistName,
                Album = s.Album,
                AlbumCoverPath = s.AlbumCoverPath,
                Genre = s.Genre,
                //here
            }).FirstOrDefault(m => m.Artist_ID == id);

            //.FirstOrDefaultAsync(m => m.Artist_ID == id);
            if (artistDTO == null)
            {
                return NotFound();
            }

            return View(artistDTO);
        }



        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //async removed
        public IActionResult Create([Bind("Artist_ID,ArtistName,Album,AlbumCoverPath,Genre")] ArtistDTO artistDTO)
        {
            var artist = new Artist()

            {
                Artist_ID = artistDTO.Artist_ID,
                ArtistName = artistDTO.ArtistName,
                Album = artistDTO.Album,
                AlbumCoverPath = artistDTO.AlbumCoverPath,
                Genre = artistDTO.Genre
            };

            if (ModelState.IsValid)
            {
                _context.Add(artist);
                _context.SaveChangesAsync();// await , removed
                return RedirectToAction(nameof(Index));
            }
            return View(artistDTO);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistDTO = _context.Artist.Select(s => new ArtistDTO()
            {
                Artist_ID = s.Artist_ID,
                ArtistName = s.ArtistName,
                Album = s.Album,
                AlbumCoverPath = s.AlbumCoverPath,
                Genre = s.Genre,
            }).FirstOrDefault(m => m.Artist_ID == id);



            if (artistDTO == null)
            {
                return NotFound();
            }
            return View(artistDTO);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Artist_ID,ArtistName,Album,AlbumCoverPath,Genre")] ArtistDTO artistDTO)
        {
            if (id != artistDTO.Artist_ID)
            {
                return NotFound();
            }

            var artist = new Artist()
            {
                Artist_ID = artistDTO.Artist_ID,
                ArtistName = artistDTO.ArtistName,
                Album = artistDTO.Album,
                AlbumCoverPath = artistDTO.AlbumCoverPath,// this will not be used on the web page
                Genre = artistDTO.Genre
            };



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Artist_ID))
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
            return View(artistDTO);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.Artist_ID == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }
        // Make sure in the views folder /Artists/Delete.cshtml it is pointing to  DeepMusic.Models.Artist, not DeepMusic.DTO.ArtistDTO.
        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.Artist_ID == id);
        }
    }
}
