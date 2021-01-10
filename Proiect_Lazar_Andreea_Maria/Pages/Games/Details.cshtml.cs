using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Lazar_Andreea_Maria.Data;
using Proiect_Lazar_Andreea_Maria.Models;

namespace Proiect_Lazar_Andreea_Maria.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Lazar_Andreea_Maria.Data.Proiect_Lazar_Andreea_MariaContext _context;

        public DetailsModel(Proiect_Lazar_Andreea_Maria.Data.Proiect_Lazar_Andreea_MariaContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
