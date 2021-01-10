using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Lazar_Andreea_Maria.Data;
using Proiect_Lazar_Andreea_Maria.Models;

namespace Proiect_Lazar_Andreea_Maria.Pages.Games
{
    public class CreateModel : GameCategoriesPageModel
    {
        private readonly Proiect_Lazar_Andreea_Maria.Data.Proiect_Lazar_Andreea_MariaContext _context;

        public CreateModel(Proiect_Lazar_Andreea_Maria.Data.Proiect_Lazar_Andreea_MariaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var book = new Game();
            book.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newGame = new Game();
            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Game>(
            newGame,
            "Game",
            i => i.Title, i => i.Creator,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newGame);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        
    }
}
