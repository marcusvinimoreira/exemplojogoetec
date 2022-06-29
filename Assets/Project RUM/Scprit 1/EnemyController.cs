using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidade = 3.5f;
    public PlayerController player;
    public GameObject inimgioMorte;
    private int vidaInimigo=1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));

        //if (this.transform.position.x <= -7)
        //{
        //    Destroy(this.gameObject);
        //}
        if(vidaInimigo<=0)
        {
            MorteInimigo();
        }


    }
    void MorteInimigo()
    {
        Instantiate(inimgioMorte, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void DamageEnemy(int dano)
    {
        vidaInimigo--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MorteInimigo();
        }
    }
}
