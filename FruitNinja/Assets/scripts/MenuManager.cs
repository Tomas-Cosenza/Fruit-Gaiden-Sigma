using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator Anim;

    public void NewGame() 
    {
        Anim.SetBool("NewGame", true);
        Invoke("LoadScene", 1);
    }

    public void Exit() 
    {
        Application.Quit();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);

    }




}
