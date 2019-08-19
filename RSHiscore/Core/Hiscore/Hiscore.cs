namespace RSHiscore
{
    class Hiscore
    {
        public SkillData[] Skills;
        public MinigameData[] Minigames;

        public Hiscore()
        {
            SetupArrays();
        }

        private void SetupArrays()
        {
            Skills = new SkillData[] {
                new SkillData("Overall"),
                new SkillData("Attack"),
                new SkillData("Defence"),
                new SkillData("Strength"),
                new SkillData("Hitpoints"),
                new SkillData("Ranged"),
                new SkillData("Prayer"),
                new SkillData("Magic"),
                new SkillData("Cooking"),
                new SkillData("Woodcutting"),
                new SkillData("Fletching"),
                new SkillData("Fishing"),
                new SkillData("Firemaking"),
                new SkillData("Crafting"),
                new SkillData("Smithing"),
                new SkillData("Mining"),
                new SkillData("Herblore"),
                new SkillData("Agility"),
                new SkillData("Thieving"),
                new SkillData("Slayer"),
                new SkillData("Farming"),
                new SkillData("Runecraft"),
                new SkillData("Hunter"),
                new SkillData("Construction")
            };

            Minigames = new MinigameData[] {
                new MinigameData("Bounty Hunter - Hunter"),
                new MinigameData("Bounty Hunter - Rogue"),
                new MinigameData("LMS - Rank"),
                new MinigameData("Clue Scrolls (all)"),
                new MinigameData("Clue Scrolls (beginner)"),
                new MinigameData("Clue Scrolls (easy)"),
                new MinigameData("Clue Scrolls (medium)"),
                new MinigameData("Clue Scrolls (hard)"),
                new MinigameData("Clue Scrolls (elite)"),
                new MinigameData("Clue Scrolls (master)")
            };
        }
    }
}
