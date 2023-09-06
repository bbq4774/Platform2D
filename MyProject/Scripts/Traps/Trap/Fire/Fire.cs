using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private static Fire instance;
    public static Fire Instance => instance;
    private Animator anima;
    [SerializeField] private bool isOn = false;
    public bool IsOn => isOn;
    [SerializeField] private float timeOn = 3f;
    [SerializeField] private float countTimeOn = 0;
    [SerializeField] private float timeDelay = 3f;
    [SerializeField] private float countTimeDelay = 0;

    private void Awake()
    {
        Fire.instance = this;
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        CountDownToOn();
        anima.SetBool("isOn", isOn);
    }

    private void CountDownToOn()
    {
        countTimeDelay += Time.deltaTime;
        if (countTimeDelay >= timeDelay)
        {
            CountDownTimeOn();
            isOn = true;
        }
        else
            isOn = false;
    }

    private void CountDownTimeOn()
    {
        countTimeOn += Time.deltaTime;
        if (countTimeOn >= timeOn)
        {
            countTimeDelay = 0;
            countTimeOn = 0;
        }
    }
}
