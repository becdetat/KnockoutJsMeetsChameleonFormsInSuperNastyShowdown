using System.ComponentModel.DataAnnotations;

namespace DingDing.Controllers.Api.Models
{
    public class CharacterPostModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        [Range(0, 100)]
        public int Strength { get; set; }

        [Required]
        [Range(0, 100)]
        public int Dexterity { get; set; }

        [Required]
        [Range(0, 100)]
        public int Constitution { get; set; }

        [Required]
        [Range(0, 100)]
        public int Intelligence { get; set; }

        [Required]
        [Range(0, 100)]
        public int Wisdom { get; set; }

        [Required]
        [Range(0, 100)]
        public int Charisma { get; set; }
    }
}