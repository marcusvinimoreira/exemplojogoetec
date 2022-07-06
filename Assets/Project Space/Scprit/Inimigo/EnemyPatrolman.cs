using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolman : MonoBehaviour
{
    public Transform[] points;
    public int pointInicial;
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[pointInicial].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointInicial].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == points[pointInicial].transform.position)
        {
            pointInicial += 1;

        }
        if (pointInicial == points.Length)
        {
            pointInicial = 0;
        }
    }
}
