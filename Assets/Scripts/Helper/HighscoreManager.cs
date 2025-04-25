using System.IO;
using Model;
using UnityEngine;

namespace Helper
{
    public static class HighscoreManager
    {
        public static void SaveHighscore(int points)
        {
            HighscoreData highscoreData = new HighscoreData();
            highscoreData.name = MenuManager.Instance.Name;
            highscoreData.points = points;

            string json = JsonUtility.ToJson(highscoreData);

            File.WriteAllText(Application.persistentDataPath + "/saveHighscore.json", json);
        }

        public static HighscoreData LoadHighscore()
        {
            if (File.Exists(Application.persistentDataPath + "/saveHighscore.json"))
            {
                string data = File.ReadAllText(Application.persistentDataPath + "/saveHighscore.json");

                var highscore = JsonUtility.FromJson<HighscoreData>(data);

                return highscore;
            }

            return new HighscoreData
            {
                name = "",
                points = 0
            };
        }
    }
}