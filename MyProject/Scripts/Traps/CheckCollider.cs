using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetDistance = 1f;

    private BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        CheckBoxCollider();
    }

    private void CheckBoxCollider()
    {
        if (player.position.y - transform.parent.position.y > offsetDistance)
            box.enabled = true;
        else
            box.enabled = false;
    }
}
