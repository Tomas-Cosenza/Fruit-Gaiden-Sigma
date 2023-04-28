using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject blade, leftDoor, rightDoor;
    [SerializeField] private Transform leftDoorClosedPos, rightDoorClosedPos, leftDoorOpenPos, rightDoorOpenPos;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private CanvasGroup cg;
    private int score;


    private void Start()
    {
        DOTween.Init();

        leftDoor.transform.DOMove(leftDoorOpenPos.position, .5f).SetEase(Ease.InOutExpo);
        rightDoor.transform.DOMove(rightDoorOpenPos.position, .5f).SetEase(Ease.InOutExpo);
    }
    public void IncreaseScore(int addedpoints) 
    {
        score += addedpoints;
        scoreText.text = score.ToString();
    }

    public void onBombHit() 
    {
        blade.SetActive(false);
        leftDoor.transform.DOMove(leftDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo);
        rightDoor.transform.DOMove(rightDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo).onComplete = (()=> cg.DOFade(1, 1).SetEase(Ease.InOutExpo).onComplete = (() => LooseScreen()));
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

    private void DoLooseScreen()
    {
        cg.DOFade(1, 1).SetEase(Ease.InOutExpo).onComplete = (() => LooseScreen());

    }
    private void LooseScreen()
    {
        cg.interactable = true;
        Time.timeScale = 0;
    }
}
