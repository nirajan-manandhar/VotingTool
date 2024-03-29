﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingModelLibrary.Models.Theme;
using Web.Data;

namespace Web.CmsControllers
{
    // This controller needed to be manual modified as below since MVC cannot autogenerate Composite Key controller
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(string ThemeName, string ID)
        {
            if (ThemeName == null || ID == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.ThemeName == ThemeName && m.ID == ID);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThemeName,ID,Type,Value,Format,Description")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(string ThemeName, string ID)
        {
            if (ThemeName == null || ID == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(ThemeName, ID);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ThemeName,ID,Type,Value,Format,Description")] Image image)
        {
            if (id != image.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ThemeName, image.ID))
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
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(string ThemeName, string ID)
        {
            if (ThemeName == null || ID == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.ThemeName == ThemeName && m.ID == ID);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string ThemeName, string ID)
        {
            var image = await _context.Images.FindAsync(ThemeName, ID);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(string ThemeName, string ID)
        {
            return _context.Images.Any(e => e.ThemeName == ThemeName && e.ID == ID);
        }
    }
}
