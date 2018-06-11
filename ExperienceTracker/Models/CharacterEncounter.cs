using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperienceTracker.Models
{
    public class CharacterEncounter : BaseModel
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public int EncounterId { get; set; }
        public virtual Encounter Encounter { get; set; }
    }
}
