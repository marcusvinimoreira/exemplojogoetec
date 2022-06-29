using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private int posAleatoria;
    public GameObject inimigos;
    public Vector2 posicao;
    public float posYA, posYB;
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //posAleatoria = Random.Range(0, 10);
        //if (posAleatoria >= 5)
        //{
        //    posicao = new Vector2(12, posYA);
        //}
        //else
        //{
        //    posicao = new Vector2(12, posYB); ;
        //}
        AddObjetosCena();
    }

    void AddObjetosCena()
    {

        if (tempo >= 2.5f)
        {
            Instantiate(inimigos, posicao, Quaternion.identity);
            tempo = 0;
        }
        else
        {
            tempo += Time.deltaTime;
        }

    }
}
