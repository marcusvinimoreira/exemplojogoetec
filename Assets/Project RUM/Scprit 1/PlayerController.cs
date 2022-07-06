using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Animator animPlayer;
    private SpriteRenderer playerS;
    public float health;
    public bool invunreable;
    public float forcaPulo;

    public LayerMask eChao;
    public float raioChao;
    public Transform verificaChao;
    public bool estaNoChao;

    public float proximoAtaque;
    public Transform verificaAtaque;
    public float raioAtaque;
    public LayerMask eInimigo;

    public int pontuacao;
    public AudioClip ataqueSom;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        playerS = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioChao, eChao);

        InputPlayer();
        AnimationFrog();
        ProximoAtaque();

        if(Input.GetKeyDown(KeyCode.M))
        {
            DamagePlayer(1);
        }
    }

    void InputPlayer()
    {
        //Jump 
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rbPlayer.velocity = new Vector2(0, forcaPulo);

        }
        //Ataque
        if (Input.GetButtonDown("Fire1") && estaNoChao)
        {
            Ataque();
        }
    }

    void Ataque()
    {

        animPlayer.SetTrigger("Attack");
        AudioManager.inst.AudioPlay(ataqueSom);
        proximoAtaque = 0.2f;

    }

    void ProximoAtaque()
    {
        if (proximoAtaque > 0)
        {

            proximoAtaque -= Time.time * Time.deltaTime;
        }

    }
    void DanoAtque()
    {
        Collider2D[] estaAtacando = Physics2D.OverlapCircleAll(verificaAtaque.position, raioAtaque, eInimigo);

        for (int i = 0; i < estaAtacando.Length; i++)
        {

            if (estaAtacando[i].CompareTag("Enemy"))
            {
                EnemyController enemy = estaAtacando[i].GetComponent<EnemyController>();


                if (enemy != null)
                {
                    pontuacao++;
                    enemy.MorteInimigo();
                   
                }
            }

        }
    }

    public void DamagePlayer(float dano)
    {
        if (health > 0)
        {

            invunreable = true;
            StartCoroutine(Damage());
            health -= dano;
            if (health < 1)
            {
                Invoke("ReloadLevel", 3f);
            }
        }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator Damage()
    {
        for (float i = 0f; i < 1f; i += 0.2f)
        {
           // playerS.enabled = false;
            playerS.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            //playerS.enabled = true;
            playerS.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        invunreable = false;
    }
    void AnimationFrog()
    {
        animPlayer.SetBool("Run", estaNoChao);
        animPlayer.SetBool("Jump", !estaNoChao);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(verificaChao.position, raioChao);
        Gizmos.DrawWireSphere(verificaAtaque.position, raioAtaque);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer(1);

        }
    }
}
