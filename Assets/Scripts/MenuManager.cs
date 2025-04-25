using System;
using System.IO;
using Helper;
using Model;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string Name;
    public TMP_Text Highscore;

    private void Awake()
    {
        if (Instance is not null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        HighscoreData highscoreData = HighscoreManager.LoadHighscore();
        Highscore.text = $"Best Score : {highscoreData.name} : {highscoreData.points}";
    }
}