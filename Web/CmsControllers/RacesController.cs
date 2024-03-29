﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingModelLibrary.Models;
using Web.ViewModels;
using Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace Web.CmsControllers
{
    [Authorize]
    public class RaceViewModel
    {
        public int ElectionId { get; set; }
        public int RaceId { get; set; }
        public string PositionName { get; set; }
        public int NumberNeeded { get; set; }
        public IList<int> RaceCandidatesIds { get; set; }
    }

    public class RacesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private State State;

        public RacesController(ApplicationDbContext context)
        {
            _context = context;
            State = _context.StateSingleton.Find(State.STATE_ID);
        }

        // GET: Races
        public async Task<IActionResult> Index()
        {
            return View(await _context.Races.Where(r => r.ElectionId == State.currentElection).ToListAsync());
        }

        // GET: Races/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Election)
                .FirstOrDefaultAsync(m => m.RaceId == id);

            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: Races/Create
        public IActionResult Create()
        {
            ViewData["Elections"] = new SelectList(_context.Elections, "ElectionId", "Name");
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaceId,ElectionId,PositionName,NumberNeeded")] Race race)
        {
            if (ModelState.IsValid)
            {
                _context.Add(race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Elections"] = new SelectList(_context.Elections, "ElectionId", "Name", race.ElectionId);
            return View(race);
        }

        // GET: Races/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races.FindAsync(id);

            var crs = await _context.CandidateRaces
                .Where(cr => cr.RaceId == id)
                .ToListAsync();

            List<int> raceCandidateIds = new List<int>();
            foreach(var cr in crs)
            {
                raceCandidateIds.Add(cr.CandidateId);
            }

            RaceViewModel model = new RaceViewModel
            {
                ElectionId = race.ElectionId,
                RaceId = race.RaceId,
                PositionName = race.PositionName,
                NumberNeeded = race.NumberNeeded,
                RaceCandidatesIds = raceCandidateIds
            };

            if (race == null)
            {
                return NotFound();
            }
            ViewData["Elections"] = new SelectList(_context.Elections, "ElectionId", "Name");
            ViewData["Candidates"] = new SelectList(_context.Candidates.Where(c=>c.ElectionId==State.currentElection), "CandidateId", "LastName");
            return View(model);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RaceViewModel model)
        {
            if (id != model.RaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var race = _context.Races.Find(id);
                    race.ElectionId = model.ElectionId;
                    race.PositionName = model.PositionName;
                    race.NumberNeeded = model.NumberNeeded;
                    _context.Update(race);

                    var crs = _context.CandidateRaces.Where(cr => cr.RaceId == id).ToList();
                    _context.RemoveRange(crs);
                    
                    foreach(var cr in model.RaceCandidatesIds)
                        _context.Add(new CandidateRace
                        {
                            CandidateId = cr,
                            RaceId = id,
                            PositionName = race.PositionName
                        });

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(model.RaceId))
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
            ViewData["Elections"] = new SelectList(_context.Elections, "ElectionId", "Name", model.ElectionId);
            return View(model);
        }

        // GET: Races/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Election)
                .FirstOrDefaultAsync(m => m.RaceId == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var race = await _context.Races.FindAsync(id);
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.RaceId == id);
        }
    }
}