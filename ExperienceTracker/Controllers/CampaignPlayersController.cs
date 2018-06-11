using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExperienceTracker.Models;

namespace ExperienceTracker.Controllers
{
    public class CampaignPlayersController : Controller
    {
        private readonly ExperienceTrackerContext _context;

        public CampaignPlayersController(ExperienceTrackerContext context)
        {
            _context = context;
        }

        // GET: CampaignPlayers
        public async Task<IActionResult> Index()
        {
            var experienceTrackerContext = _context.CampaignPlayer.Include(c => c.Campaign).Include(c => c.Player);
            return View(await experienceTrackerContext.ToListAsync());
        }

        // GET: CampaignPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignPlayer = await _context.CampaignPlayer
                .Include(c => c.Campaign)
                .Include(c => c.Player)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (campaignPlayer == null)
            {
                return NotFound();
            }

            return View(campaignPlayer);
        }

        // GET: CampaignPlayers/Create
        public IActionResult Create()
        {
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Id");
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            return View();
        }

        // POST: CampaignPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,CampaignId")] CampaignPlayer campaignPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaignPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Id", campaignPlayer.CampaignId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", campaignPlayer.PlayerId);
            return View(campaignPlayer);
        }

        // GET: CampaignPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignPlayer = await _context.CampaignPlayer.FindAsync(id);
            if (campaignPlayer == null)
            {
                return NotFound();
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Id", campaignPlayer.CampaignId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", campaignPlayer.PlayerId);
            return View(campaignPlayer);
        }

        // POST: CampaignPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,CampaignId")] CampaignPlayer campaignPlayer)
        {
            if (id != campaignPlayer.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaignPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignPlayerExists(campaignPlayer.PlayerId))
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
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Id", campaignPlayer.CampaignId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", campaignPlayer.PlayerId);
            return View(campaignPlayer);
        }

        // GET: CampaignPlayers/Delete/5
        [HttpGet]
        [Route("Campaigns/{campaignId}/Players/{playerId}/")]
        public async Task<IActionResult> Delete(int? campaignId, int? playerId)
        {
            if (campaignId == null || playerId == null)
            {
                return NotFound();
            }

            var campaignPlayer = await _context.CampaignPlayer
                .Include(c => c.Campaign)
                .Include(c => c.Player)
                .FirstOrDefaultAsync(m => m.PlayerId == playerId && m.CampaignId == campaignId);
            if (campaignPlayer == null)
            {
                return NotFound();
            }

            return View(campaignPlayer);
        }

        // POST: CampaignPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int campaignId, int playerId)
        {
            var campaignPlayer = await _context.CampaignPlayer.FindAsync(campaignId, playerId);
            _context.CampaignPlayer.Remove(campaignPlayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignPlayerExists(int id)
        {
            return _context.CampaignPlayer.Any(e => e.PlayerId == id);
        }
    }
}
