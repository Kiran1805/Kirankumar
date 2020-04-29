using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetDetailsController : ControllerBase
    {
        private readonly FleetDetailContext _context;

        public FleetDetailsController(FleetDetailContext context)
        {
            _context = context;
        }

        // GET: api/FleetDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FleetDetail>>> GetFleetDetails()
        {
            return await _context.FleetDetails.ToListAsync();
        }

        // GET: api/FleetDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FleetDetail>> GetFleetDetail(int id)
        {
            var fleetDetail = await _context.FleetDetails.FindAsync(id);

            if (fleetDetail == null)
            {
                return NotFound();
            }

            return fleetDetail;
        }

        // PUT: api/FleetDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFleetDetail(int id, FleetDetail fleetDetail)
        {
            if (id != fleetDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(fleetDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FleetDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FleetDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FleetDetail>> PostFleetDetail(FleetDetail fleetDetail)
        {
            _context.FleetDetails.Add(fleetDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFleetDetail", new { id = fleetDetail.Id }, fleetDetail);
        }

        // DELETE: api/FleetDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FleetDetail>> DeleteFleetDetail(int id)
        {
            var fleetDetail = await _context.FleetDetails.FindAsync(id);
            if (fleetDetail == null)
            {
                return NotFound();
            }

            _context.FleetDetails.Remove(fleetDetail);
            await _context.SaveChangesAsync();

            return fleetDetail;
        }

        private bool FleetDetailExists(int id)
        {
            return _context.FleetDetails.Any(e => e.Id == id);
        }
    }
}
