using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RSHiscore {

    public partial class MainWindow : Window {

        private HiscoreFetcher parser;

        public MainWindow()
        {
            InitializeComponent();
            InitializeHiscoreTypeComboBox();
            parser = new HiscoreFetcher();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.IsEnabled = false;
            SearchButton.Content = "Loading";
            await PopulateGridsAsync();
            SearchButton.IsEnabled = true;
            SearchButton.Content = "Search";
        }

        private async Task PopulateGridsAsync()
        {
            SkillsDataGrid.Items.Clear();
            MinigamesDataGrid.Items.Clear();

            string playerName = PlayerNameTextBox.Text.Replace(' ', '_');
            HiscoreType type = HiscoreType.ByName(HiscoreTypeComboBox.Text);
            Hiscore hiscore = await parser.FetchHiscoreAsync(playerName, type);

            if (hiscore == null)
            {
                PlayerNameTextBox.Text = "There was an issue fetching stats for " + playerName;
                return;
            }

            foreach (SkillData skill in hiscore.Skills)
            {
                SkillsDataGrid.Items.Add(skill);
            }

            foreach (MinigameData minigame in hiscore.Minigames)
            {
                MinigamesDataGrid.Items.Add(minigame);
            }
        }

        private void InitializeHiscoreTypeComboBox()
        {
            foreach (HiscoreType type in HiscoreType.Values())
            {
                HiscoreTypeComboBox.Items.Add(type.Name);
            }
            HiscoreTypeComboBox.SelectedIndex = 0;
        }
    }
}
