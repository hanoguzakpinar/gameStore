using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}