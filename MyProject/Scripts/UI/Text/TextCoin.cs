using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoin : MonoBehaviour
{
    [SerializeField] private Text textCoin;

    private void Update()
    {
        textCoin.text = "x" + ItemsCollector.Instance.coins;
    }
}
