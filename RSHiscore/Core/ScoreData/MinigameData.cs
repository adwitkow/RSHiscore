namespace RSHiscore
{
    class MinigameData
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }

        public MinigameData(string name, int rank, int score)
        {
            this.Name = name;
            this.Rank = rank;
            this.Score = score;
        }

        public MinigameData(string name) : this(name, -1, -1) { }

        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(Name) || Score == -1);
        }
    }
}
