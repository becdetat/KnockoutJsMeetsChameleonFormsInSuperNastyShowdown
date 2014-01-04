using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Humanizer;

namespace DingDing.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }

    public static class PreRolledCharacters
    {
        public static Character Minty
        {
            get
            {
                return new Character
                {
                    Name = "Minty the Minotaur",
                    Race = "Minotaur",
                    Class = "Fighter",
                    Strength = 14,
                    Dexterity = 8,
                    Constitution = 10,
                    Intelligence = 8,
                    Wisdom = 10,
                    Charisma = 10,
                };
            }
        }

        public static Character Gary
        {
            get
            {
                return new Character
                {
                    Name = "Gary the Grey",
                    Race = "Gray Elf",
                    Class="Wizard",
                    Strength = 8,
                    Dexterity = 8,
                    Constitution = 10,
                    Intelligence = 12,
                    Wisdom = 10,
                    Charisma = 10
                };
            }
        }

        public static Character Maggie
        {
            get
            {
                return new Character
                {
                    Name = "Maggie the Astral-dwelling Militarist",
                    Race = "Githyanki",
                    Class = "Astral-dwelling Militarist",
                    Strength = 10,
                    Charisma = 2,
                    Dexterity = 12,
                    Constitution = 12,
                    Wisdom = 8,
                    Intelligence = 6,
                };
            }
        }
    }
}