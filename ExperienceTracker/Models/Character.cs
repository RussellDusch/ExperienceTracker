using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExperienceTracker.Models
{
    public class Character : BaseModel
    {
        public Character()
        {
            Encounters = new HashSet<CharacterEncounter>();
        }

        public string Name { get; set; }
        public virtual ICollection<CharacterEncounter> Encounters { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [NotMapped]
        public int Experience
        {
            get
            {
                return Encounters.Count() > 0
                    ? Encounters.Select(e => e.Encounter.PerCharacterExperience).Aggregate((int e1, int e2) => e1 + e2)
                    : 0;
            }
        }

    }
}
