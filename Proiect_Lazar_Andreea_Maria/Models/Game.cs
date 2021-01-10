using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Lazar_Andreea_Maria.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Game Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required,
StringLength(50, MinimumLength = 3)]
        public string Creator { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [Range(1,300)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }

    }
}
