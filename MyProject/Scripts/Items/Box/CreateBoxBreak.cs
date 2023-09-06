using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoxBreak : MonoBehaviour
{
    private static CreateBoxBreak instance;
    public static CreateBoxBreak Instance => instance;
    [SerializeField] private Transform boxBreak;

    private void Awake()
    {
        CreateBoxBreak.instance = this;
    }

    public void CreateBoxBreaks(Vector2 position)
    {
        Transform obj = Instantiate(boxBreak, position, Quaternion.identity);

        obj.gameObject.SetActive(true);
        obj.parent = transform;
    }
}
