using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuLevel : MonoBehaviour
{
    [SerializeField] private Animator _authorsPanelAnimator;

    public void ToggleAuthorsPanel()
    {
        _authorsPanelAnimator.SetBool("Show", !_authorsPanelAnimator.GetBool("Show"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
