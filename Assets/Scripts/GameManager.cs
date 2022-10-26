using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float timeToCombo = 0.4f;
    public static Action<int> onScoreUpdated;

    public static GameManager instance;
    public bool isStarted;
    public int score;
    private float timer = 30f;
    private bool isComboStarted;
    private bool canCombo;
    private float comboTimer;
    private int comboCounter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    private void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        timer = 30f;
        score = 0;
        gameOverPanel.SetActive(false);
        isStarted = true;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseCombo()
    {
        isComboStarted = true;
        comboTimer = 0;
        comboCounter++;
        if (comboCounter > 1)
        {
            comboText.text = "Combo x" + comboCounter.ToString();
        }
    }
    public void AddScore(int amount)
    {
        score += amount * comboCounter;
        scoreText.text = "Score: " + score.ToString();
        onScoreUpdated?.Invoke(amount * comboCounter);
    }

    private void Update()
    {
        if (isComboStarted)
        {
            comboTimer += Time.deltaTime;
        }
        if (comboTimer > timeToCombo)
        {
            isComboStarted = false;
            comboCounter = 0;
            comboText.text = "";
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            isStarted = false;
            if (!gameOverPanel.activeSelf)
            {
                gameOverPanel.SetActive(true);
            }
        }
        timerText.text = timer.ToString("F2");
    }
}
