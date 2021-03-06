﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    private AudioManager _am;

    public bool isGame;
    
    [SerializeField]
    private float gameTime;
    
    public GameObject CtTarget;
    public GameObject[] targets = new GameObject[1];
    [SerializeField]
    public int maxCount;
    [SerializeField]
    public int currentCount;

    public int scores;
    
    [SerializeField]
    private float minSize;
    [SerializeField]
    private float maxSize;

    [Header("UI")]
    public Text scoreTxt;

    public Text comboTxt;

    public Text timeTxt;

    public GameObject gameOverPanel;

    public GameObject gameOverPos;

    public Button backToMenuButton;

    public Text playerScoreTxt;

    public Text bestScoreTxt;
   

    [Header("CtBodyTarget")] 
    public float minTime;

    public float maxTime;

    public float _currentTime;

    private float RndTime;


    [Header("Combo System")] 
    public int currentCombo;

    public int ultraKill;

    public int monsterKill;

    public int humiliation;

    public int holyShit;

    public int rampage;

    public int godLike;
    
    
    void Start()
    {
        RndTime = Random.Range(minTime, maxTime);
        _currentTime = 0;
        _am = GetComponent<AudioManager>();
        scores = 0;
        gameTime = PlayerPrefs.GetInt("GameTime");
    }

    void Update()
    {
        if (isGame)
        {
            UiUpdate();
            if (gameTime > 0)
                gameTime -= Time.deltaTime;
            else
            {
                GameOver(scores);
                isGame = false;
            }

            CtTargetSpawn();
            if (currentCount < maxCount)
            {
                var go = Instantiate(targets[Random.Range(0, targets.Length)],
                    new Vector2(Random.Range(-8, 8), Random.Range(-4, 4)), Quaternion.identity);
                float rndSize = Random.Range(minSize, maxSize);
                go.transform.localScale = new Vector2(rndSize, rndSize);
                currentCount++;
            }
        }
    }

    public void Delete()
    {
        currentCount--;
    }

    public void AddScore()
    {
        scores++;
    }

    public void SubtractScore()
    {
        scores -= 5;
    }

    public void Combo()
    {
        switch (currentCombo)
        {
            case 5: _am.PlaySound("UltraKill");
                    break;
            case 10: _am.PlaySound("MonsterKill");
                    break;
            case 15: _am.PlaySound("Humiliation");
                    break;
            case 20 : _am.PlaySound("HolyShit");
                    break;
            case 30: _am.PlaySound("Rampage");
                    break;
            case 45: _am.PlaySound("Godlike");
                    break;
        }
    }

    private void CtTargetSpawn()
    {
        if (_currentTime >= RndTime)
        {
            RndTime = Random.Range(minTime, maxTime);
            Instantiate(CtTarget, transform.position, Quaternion.identity);
            _currentTime = 0;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }
    private void UiUpdate()
    {
        comboTxt.text = "COMBO: X"  + currentCombo.ToString();
        if (currentCombo < ultraKill)
        {
            comboTxt.color = Color.black;
        }
        if (currentCombo >= monsterKill)
        {
            comboTxt.color = Color.green;
        }
        if (currentCombo >= holyShit)
        {
            comboTxt.color = Color.yellow;
        }
        if ( currentCombo >= rampage)
        {
            comboTxt.color = Color.red;
        }
        
        if (scores < 0)
            scores = 0;
        scoreTxt.text = scores.ToString();

        timeTxt.text = gameTime.ToString("000");
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");  
    }

    private void GameOver(int score)
    {
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        gameOverPanel.SetActive(true);
        backToMenuButton.transform.position = gameOverPos.transform.position;
        playerScoreTxt.text = "Your SCORE: " + score.ToString();
        bestScoreTxt.text = "BEST SCORE: " +PlayerPrefs.GetInt("BestScore").ToString();
    }
}
