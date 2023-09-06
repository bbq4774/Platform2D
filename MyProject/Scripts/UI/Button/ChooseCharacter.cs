using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacter : PlayerManagement
{
    private static ChooseCharacter instance;
    public static ChooseCharacter Instance => instance;

    [SerializeField] private Text nameCharacter;

    private int index = 0;
    public int Index => index;
    private int length;

    private void Awake()
    {
        ChooseCharacter.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        length = players.Length;
    }

    private void Update()
    {
        nameCharacter.text = players[index].name;
    }

    public void ButtonNext()
    {
        DisableObj(index);

        index++;
        if (index == length)
            index = 0;

        EnableObj(index);
    }

    public void ButtonLast()
    {
        DisableObj(index);

        index--;
        if (index < 0)
            index = length - 1;
        
        EnableObj(index);
    }

    public void ButtonExit()
    {
        SceneManager.LoadScene("Start");
    }
}
