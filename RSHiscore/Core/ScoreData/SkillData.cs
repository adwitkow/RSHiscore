namespace RSHiscore
{
    class SkillData
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }

        public SkillData(string name, int rank, int level, int xp)
        {
            this.Name = name;
            this.Rank = rank;
            this.Level = level;
            this.XP = xp;
        }

        public SkillData(string name) : this(name, -1, -1, -1) { }

        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(Name) || Level == -1 || XP == -1);
        }
    }
}
