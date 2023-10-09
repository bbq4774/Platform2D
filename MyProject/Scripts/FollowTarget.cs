using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(0, 0, -10);
    [SerializeField] private float speed = 10f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed);
    }
}
