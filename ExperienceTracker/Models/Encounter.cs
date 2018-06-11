using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExperienceTracker.Models
{
    public class Encounter : BaseModel
    {
        public Encounter()
        {
            Monsters = new HashSet<MonsterEncounter>();
            PlayerCharacters = new HashSet<CharacterEncounter>();
        }

        public string Name { get; set; }
        public virtual ICollection<MonsterEncounter> Monsters { get; set; }
        public virtual ICollection<CharacterEncounter> PlayerCharacters { get; set; }
        public int AdditionalExperience { get; set; }
        public int? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        [NotMapped]
        public int PerCharacterExperience
        {
            get
            {
                return PlayerCharacters.Count() > 0
                    ? (MonsterExperience + AdditionalExperience) / PlayerCharacters.Count()
                    : 0;
            }
        }

        [NotMapped]
        public int TotalExperience
        {
            get
            {
                return MonsterExperience + AdditionalExperience;
            }
        }

        [NotMapped]
        public int MonsterExperience
        {
            get
            {
                return Monsters.Count() > 0
                    ? Monsters
                        .Select(m => m.Monster.Experience * m.Count)
                        .Aggregate((int e1, int e2) => e1 + e2)
                    : 0;
            }
        }

        [NotMapped]
        public int AdjustedExperience
        {
            get
            {
                return Convert.ToInt32(Math.Round(MonsterExperience * EncounterMultiplier(Monsters.Count())));
            }
        }

        private double EncounterMultiplier(int monsterCount)
        {
            if (monsterCount >= 15)
            {
                return 4;
            }
            else if (monsterCount >= 11)
            {
                return 3;
            }
            else if (monsterCount >= 7)
            {
                return 2.5;
            }
            else if (monsterCount >= 3)
            {
                return 2;
            }
            else if (monsterCount == 2)
            {
                return 1.5;
            }
            else return 1;
        }
    }
}