using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
   private float speedy;
    public Vector2 direcao;
    private Vector2 direcaoHeroi;

    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer spr;



    // Start is called before the first frame update
    void Start()
    {
        speedy = 3.0f;
        direcao = Vector2.zero;
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();


    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direcao * speedy * Time.deltaTime);
        if (direcao.x != 0 || direcao.y != 0)
        {
            PlayerAnimator(direcao);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }

        MovePlayer();

    }
    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direcao * speedy * Time.deltaTime);

    }

    void PingPongColor(int x)
    {
        spr.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(x * Time.time, 0.5f));
    }

    void MovePlayer()
    {

        direcao = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {

            direcao += Vector2.up;
            direcaoHeroi = direcao;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector2.down;
            direcaoHeroi = direcao;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direcao += Vector2.left;
            direcaoHeroi = direcao;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direcao += Vector2.right;
            direcaoHeroi = direcao;
        }
    }

    void PlayerAnimator(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);
        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }
}
