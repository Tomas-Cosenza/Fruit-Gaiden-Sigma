using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor, rightDoor;
    [SerializeField] private Transform leftDoorClosedPos, rightDoorClosedPos, leftDoorOpenPos, rightDoorOpenPos;
    //[SerializeField] private Animator Anim;
    private void Start()
    {
        DOTween.Init();
        leftDoor.transform.DOMove(leftDoorOpenPos.position, 1.5f).SetEase(Ease.InExpo);
        rightDoor.transform.DOMove(rightDoorOpenPos.position, 1.5f).SetEase(Ease.InExpo);
    }

    public void NewGame() 
    {
        //Anim.SetBool("NewGame", true);
        leftDoor.transform.DOMove(leftDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo);
        rightDoor.transform.DOMove(rightDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo).onComplete = (() => LoadScene());
    }
    
    public void Exit()
    {
        leftDoor.transform.DOMove(leftDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo);
        rightDoor.transform.DOMove(rightDoorClosedPos.position, 1.5f).SetEase(Ease.InExpo).onComplete = (() => Application.Quit());
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);

    }




}
