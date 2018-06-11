using System.Collections.Generic;

namespace ExperienceTracker.Models
{
    public class Monster : BaseModel
    {
        public Monster()
        {
            Encounters = new HashSet<MonsterEncounter>();
        }

        public string Name { get; set; }
        public int Experience { get; set; }
        public virtual ICollection<MonsterEncounter> Encounters { get; set; }
    }
}