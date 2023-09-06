using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] protected Transform[] players;
    private int index;

    protected virtual void Start()
    {
        //index = ChooseCharacter.Instance.Index;
        index = 0;
        Disable();
        EnableObj(index);
    }

    protected void Disable()
    {
        foreach (Transform obj in players)
            obj.gameObject.SetActive(false);
    }

    protected void EnableObj(int index)
    {
        players[index].gameObject.SetActive(true);
    }

    protected void DisableObj(int index)
    {
        players[index].gameObject.SetActive(false);
    }
}
