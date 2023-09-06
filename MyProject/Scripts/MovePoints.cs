using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    [Header("Point to move")]
    [SerializeField] protected Transform[] points;
    [SerializeField] protected float speed = 2f;

    protected Transform point;
    protected int index;

    protected virtual void Start()
    {
        point = points[0];
        index = 0;
    }

    protected virtual void Update()
    {
        ChangePoints();
        MoveToPoint();
    }

    protected virtual void ChangePoints()
    {
        if (Vector2.Distance(transform.position, point.position) < 0.1f)
        {
            index++;
            if (index == points.Length)
                index = 0;
            point = points[index];
        }
    }

    protected virtual void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
