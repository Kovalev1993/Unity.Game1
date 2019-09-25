using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Animator AuthorsPanelAnimator;

    public void AuthorsButton(){
        AuthorsPanelAnimator.SetBool("Show", !AuthorsPanelAnimator.GetBool("Show"));
    }

    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }
    
    public void ExitGame() {
        Application.Quit();
    }
}
