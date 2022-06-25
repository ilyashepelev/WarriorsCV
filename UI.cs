using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;

    public void UpdateScoreAndLevel()
    {
        _levelText.text = $"Level: {Stats.Level}";
        _scoreText.text = "Score: " + Stats.Score.ToString("D4");
    }


    public void UpdateHalthText(int hp)
    {
        _healthText.text = $"HP: {hp}";
    }
}
