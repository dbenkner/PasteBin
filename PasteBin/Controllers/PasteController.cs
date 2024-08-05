using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasteBin.Data;
using PasteBin.DTOs;
using PasteBin.Models;
using PasteBin.Services;
using System.Data.Common;

namespace PasteBin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasteController : ControllerBase
    {
        private readonly PasteBinContext _context;

        public PasteController(PasteBinContext context)
        {
            _context = context;
        }
        [HttpGet("{url}")]
        public async Task<IActionResult> GetPaste(string url)
        {
            var paste = await _context.Pastes.Where(p => p.PasteURL == url).FirstOrDefaultAsync();
            if (paste == null)
            {
                return BadRequest();
            }
            return Ok(paste);
        }
        [HttpPost]
        public async Task<ActionResult<Paste>> AddPaste(NewPaste newPasteDTO)
        {
            if (newPasteDTO == null) return BadRequest();

            Paste paste = new Paste()
            {
                PasteText = newPasteDTO.PasteText,
                UserID = newPasteDTO.UserId,
                ExpirationDate = newPasteDTO.ExpirationDate,
                PasteURL = RandomService.GenerateRandomStaring(8)
            };
            await _context.AddAsync(paste);
            await _context.SaveChangesAsync();

            return Ok(paste);
        }
    }
}
