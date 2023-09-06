using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    private static ItemsCollector instance;
    public static ItemsCollector Instance => instance;
    
    public int fruits = 0;
    public int coins = 0;

    private void Awake()
    {
        ItemsCollector.instance = this;
    }
}
