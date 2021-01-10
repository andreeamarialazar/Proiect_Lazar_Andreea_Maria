using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Lazar_Andreea_Maria.Models
{
    public class GameData
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<GameCategory> GameCategories { get; set; }
    }
}
