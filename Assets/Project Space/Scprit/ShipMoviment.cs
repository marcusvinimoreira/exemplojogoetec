using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoviment : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveX, moveY;
    public float velocidade;

    public Transform posicaoTiro;
    public GameObject tiro;
    public GameObject tiro2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();

    }

    void ShipMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveX * velocidade, moveY * velocidade);
  
    }
}
