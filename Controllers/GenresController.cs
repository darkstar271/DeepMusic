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
    public class GenresController : Controller
    {
        private readonly DeepMusicDbContext _context;

        public GenresController(DeepMusicDbContext context)
        {
            _context = context;
        }
        // Change made to use DTO – Data Transfer Objects.
        // https://gavilan.blog/2019/03/18/asp-net-core-2-2-data-transfer-objects-dtos-and-automapper/
        // GET: Genres
        public async Task<IActionResult> Index()
        {

            var Genres = _context.Genres.Select(s => new GenresDTO()
            {
                Genres_ID = s.Genres_ID,
                Genre = s.Genre,
                //Artist_ID = s.Artist_ID,
                //ArtistName = s.ArtistName,
                //Album = s.Album,
                //AlbumCoverPath = s.AlbumCoverPath,




                //  TracksTrack_ID = s.TracksTrack_ID
            }).ToListAsync();
            return View(await Genres);




            //return View(await _context.Genres.ToListAsync());
        }
        // Change made to use DTO – Data Transfer Objects.
        // GET: Genres/Details/5
        //public async Task<IActionResult> Details(int? id)
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genresDTO = _context.Genres.Select(s => new GenresDTO()

            {
                Genres_ID = s.Genres_ID,
                Genre = s.Genre,



            }).FirstOrDefault(m => m.Genres_ID == id);
            //= await _context.Genres
            //.FirstOrDefaultAsync(m => m.Genres_ID == id);
            if (genresDTO == null)
            {
                return NotFound();
            }

            return View(genresDTO);
        }

        // Change made to use DTO – Data Transfer Objects.
        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Genres_ID,Genre")] GenresDTO genresDTO)
        {

            var genres = new Genres()

            {
                Genres_ID = genresDTO.Genres_ID,
                Genre = genresDTO.Genre,
            };



            if (ModelState.IsValid)
            {
                _context.Add(genres);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genresDTO);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genresDTO = _context.Genres.Select(s => new GenresDTO()
            {
                Genres_ID = s.Genres_ID,
                Genre = s.Genre,
            }).FirstOrDefault(m => m.Genres_ID == id);

            if (genresDTO == null)
            {
                return NotFound();
            }
            return View(genresDTO);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Genres_ID,Genre")] GenresDTO genresDTO)
        {
            if (id != genresDTO.Genres_ID)
            {
                return NotFound();
            }

            var genres = new Genres()
            {
                Genres_ID = genresDTO.Genres_ID,
                Genre = genresDTO.Genre
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenresExists(genres.Genres_ID))
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
            return View(genresDTO);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _context.Genres
                .FirstOrDefaultAsync(m => m.Genres_ID == id);
            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
        }
        // the Delete.cshtlm must be left pointing to the @model DeepMusic.Models.Genres unlike the other one's which point to @model DeepMusic.DTO.GenresDTO
        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genres = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenresExists(int id)
        {
            return _context.Genres.Any(e => e.Genres_ID == id);
        }
    }
}
