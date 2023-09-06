using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    private static Collected instance;
    public static Collected Instance => instance;

    private void Awake()
    {
        Collected.instance = this;
    }

    private void Start()
    {
        DisableObj();
    }

    public void CreateAnimaCollected(Vector3 pos)
    {
        transform.position = pos;
        transform.gameObject.SetActive(true);
    }

    private void DisableObj()
    {
        transform.gameObject.SetActive(false);
    }
}
