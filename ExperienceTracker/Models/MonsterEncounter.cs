namespace ExperienceTracker.Models
{
    public class MonsterEncounter : BaseModel
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int EncounterId { get; set; }
        public Encounter Encounter { get; set; }
        public int Count { get; set; }
    }
}
