using System.Collections.Generic;

namespace ExperienceTracker.Models
{
    public class Player : BaseModel
    {
        public Player()
        {
            Characters = new HashSet<Character>();
            Campaigns = new HashSet<CampaignPlayer>();
        }

        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<CampaignPlayer> Campaigns { get; set; }
    }
}