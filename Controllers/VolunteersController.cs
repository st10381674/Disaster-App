﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace WebApplication8.Controllers
    {
        [Authorize(Roles = "Admin")] // 👈 Only Admins
        public class VolunteersController : Controller
        {
            private readonly ApplicationDbContext _context;

            public VolunteersController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Volunteers
            public async Task<IActionResult> Index()
            {
                return View(await _context.Volunteers.ToListAsync());
            }

            // GET: Volunteers/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var volunteer = await _context.Volunteers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (volunteer == null)
                {
                    return NotFound();
                }

                return View(volunteer);
            }

            // GET: Volunteers/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Volunteers/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,FullName,Email,PhoneNumber,DateJoined,Status")] Volunteer volunteer)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(volunteer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(volunteer);
            }

            // GET: Volunteers/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var volunteer = await _context.Volunteers.FindAsync(id);
                if (volunteer == null)
                {
                    return NotFound();
                }
                return View(volunteer);
            }

            // POST: Volunteers/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,PhoneNumber,DateJoined,Status")] Volunteer volunteer)
            {
                if (id != volunteer.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(volunteer);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VolunteerExists(volunteer.Id))
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
                return View(volunteer);
            }

            // GET: Volunteers/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var volunteer = await _context.Volunteers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (volunteer == null)
                {
                    return NotFound();
                }

                return View(volunteer);
            }

            // POST: Volunteers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var volunteer = await _context.Volunteers.FindAsync(id);
                if (volunteer != null)
                {
                    _context.Volunteers.Remove(volunteer);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool VolunteerExists(int id)
            {
                return _context.Volunteers.Any(e => e.Id == id);
            }
        }

    }
}