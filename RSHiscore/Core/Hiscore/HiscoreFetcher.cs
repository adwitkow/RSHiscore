using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RSHiscore
{
    class HiscoreFetcher
    {
        private const string HISCORE_URL = "https://secure.runescape.com/m=hiscore_oldschool{0}/index_lite.ws?player={1}";

        public async Task<Hiscore> FetchHiscoreAsync(string playerName, HiscoreType type)
        {
            Hiscore hiscore = new Hiscore();
            string url = string.Format(HISCORE_URL, type.UrlNode, playerName);
            string response = await FetchAsync(url);

            if (response == null)
            {
                return null;
            }

            string[] lines = response.TrimEnd('\n').Split('\n');

            int skillsCount = hiscore.Skills.Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] details = lines[i].Split(',');

                if (i < skillsCount)
                {
                    SkillData skill = hiscore.Skills[i];
                    skill.Rank = int.Parse(details[0]);
                    skill.Level = int.Parse(details[1]);
                    skill.XP = int.Parse(details[2]);
                }
                else
                {
                    MinigameData minigame = hiscore.Minigames[i - skillsCount];
                    minigame.Rank = int.Parse(details[0]);
                    minigame.Score = int.Parse(details[1]);
                }
            }

            return hiscore;
        }
        
        private async Task<string> FetchAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            WebResponse response = null;
            StreamReader reader = null;

            try
            {
                response = await request.GetResponseAsync();
                reader = new StreamReader(response.GetResponseStream());

                return await reader.ReadToEndAsync();
            }
            catch (WebException)
            {
                return null;
            }
            finally
            {
                if (response != null) response.Dispose();
                if (reader != null) reader.Dispose();
            }
        }
    }
}
