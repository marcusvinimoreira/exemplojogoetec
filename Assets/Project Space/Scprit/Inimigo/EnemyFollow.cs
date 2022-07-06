using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float distAtaque;
    public float stopDist;

    public float speed;
    public float valorSpeedInicial;

    private bool isMoving;
    public bool liberarPers;

   

    private float PlayerDistance()
    {
        return Vector2.Distance(player.transform.position, transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        valorSpeedInicial = speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = PlayerDistance();
        isMoving = (distance < distAtaque);
        LiberaPerseguir();
        Perseguir();
        RotateTowardsTarget();
    }

    void LiberaPerseguir()
    {

        if (isMoving==true)
        {
            liberarPers = true;
        }
        else
        {
            liberarPers = false;
        }
    }

    void Perseguir()
    {
        if (liberarPers)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist <= stopDist)
            {
                speed = 0;
            }
            else
            {
                speed = valorSpeedInicial;
            }

        }

    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
