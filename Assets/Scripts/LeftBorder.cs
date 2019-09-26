using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponentInParent<Player>() != null)
            SceneManager.LoadScene("Menu");
        else
            Destroy(collider.gameObject);
    }
}
