using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score;
    public GameObject panel;

    public TMP_Text scoreText;
    public TMP_Text bestscore;

    public void IncreaseScore(int addedpoints) 
    {
        score += addedpoints;
        scoreText.text = score.ToString();
    }

    public void onBombHit() 
    {        
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
