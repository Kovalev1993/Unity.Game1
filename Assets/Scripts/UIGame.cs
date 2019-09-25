using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void ChangeCoinsText(int coins)
    {
        _coinsText.text = "Монет собрано: " + coins.ToString();
    }
}
