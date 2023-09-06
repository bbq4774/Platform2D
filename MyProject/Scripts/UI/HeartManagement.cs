using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManagement : MonoBehaviour
{
    private static HeartManagement instance;
    public static HeartManagement Instance => instance;

    [SerializeField] private Transform[] hearts;
    private int index;

    private void Awake()
    {
        HeartManagement.instance = this;
    }

    private void Start()
    {
        index = hearts.Length - 1;
    }

    public void DisableObj()
    {
        hearts[index].gameObject.SetActive(false);
        index--;
    }

    public void AbleObj()
    {
        index++;
        hearts[index].gameObject.SetActive(true);
    }
}
