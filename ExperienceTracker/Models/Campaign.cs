using System.Collections.Generic;

namespace ExperienceTracker.Models
{
    public class Campaign : BaseModel
    {
        public Campaign()
        {
            Encounters = new HashSet<Encounter>();
            Players = new HashSet<CampaignPlayer>();
            Characters = new HashSet<Character>();
        }
        
        public string Name { get; set; }
        public ICollection<Encounter> Encounters { get; set;}
        public ICollection<CampaignPlayer> Players { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
