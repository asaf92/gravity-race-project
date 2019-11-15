using System;
using UnityEngine;
using Game.Constants;
using Presentation.UI.Constants;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreController : MonoBehaviour
{
    private Text _highScoreText;

    void OnEnable()
    {
        try
        {
            _highScoreText = GetComponent<Text>();

            var highScore = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(SettingsKeys.HighScore))
                .ToString(HudMessages.TimeStringFormat);

            _highScoreText.text = highScore;
            Debug.Log($"Set highScore to {highScore}");
        }
        catch(Exception exception)
        {
            Debug.LogError($"Error in high-score screen:\n{exception.Message}");
        }
    }
}
