using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Animator AuthorsPanelAnimator;

    private static UI _ui = null;

    private void Start()
    {
        if(_ui == null)
            _ui = this;
        else if(_ui != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

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
