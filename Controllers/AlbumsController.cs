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
    public class AlbumsController : Controller
    {
        private readonly DeepMusicDbContext _context;

        public AlbumsController(DeepMusicDbContext context)
        {
            _context = context;
        }

        // GET: Albums
        // Change made to use DTO – Data Transfer Objects.
        // https://gavilan.blog/2019/03/18/asp-net-core-2-2-data-transfer-objects-dtos-and-automapper/
        public async Task<IActionResult> Index()
        {
            var Albums = _context.Albums.Select(s => new AlbumsDTO()
            {
                Album_ID = s.Album_ID,
                ArtistName = s.ArtistName,
                Track = s.Track,
                AlbumCoverPath = s.AlbumCoverPath,
                Genre = s.Genre,
                //  TracksTrack_ID = s.TracksTrack_ID
            }).ToListAsync();


            return View(await Albums);

            // old code
            //return View(await _context.Albums.ToListAsync());
        }

        // GET: Albums/Details/5
        // Change made to use DTO – Data Transfer Objects.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumsDTO = _context.Albums.Select(s => new AlbumsDTO()
            //.FirstOrDefaultAsync(m => m.Album_ID == id)

            //var Albums = _context.Albums.Select(s => new AlbumsDTO()
            {
                Album_ID = s.Album_ID,
                ArtistName = s.ArtistName,
                Track = s.Track,
                AlbumCoverPath = s.AlbumCoverPath,
                Genre = s.Genre,
                //  TracksTrack_ID = s.TracksTrack_ID
            }).FirstOrDefault(m => m.Album_ID == id);


            if (albumsDTO == null)
            {
                return NotFound();
            }

            return View(albumsDTO);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Album_ID,ArtistName,Track,AlbumCoverPath,Genre")] AlbumsDTO albumsDTO)
        {
            var albums = new Albums()
            {
                Album_ID = albumsDTO.Album_ID,
                //// Start here from NetChicken https://github.com/Netchicken/VisistorManagment2019Students/blob/master/Controllers/StaffNamesController.cs
                // Names next


            }
            if (ModelState.IsValid)
            {
                _context.Add(albums);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albums);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Albums albums = await _context.Albums.FindAsync(id);

            AlbumsDTO albumsDto = new AlbumsDTO();

            albumsDto.Album_ID = albums.Album_ID;
            albumsDto.AlbumCoverPath = albums.AlbumCoverPath;


            if (albums == null)
            {
                return NotFound();
            }
            return View(albumsDto);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Album_ID,ArtistName,Track,AlbumCoverPath,Genre")] Albums albums)
        {
            if (id != albums.Album_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albums);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumsExists(albums.Album_ID))
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
            return View(albums);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .FirstOrDefaultAsync(m => m.Album_ID == id);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albums = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(albums);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumsExists(int id)
        {
            return _context.Albums.Any(e => e.Album_ID == id);
        }
    }
}
