using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControle : MonoBehaviour
{
    public Image vidaBar;
    public Text qtdVida;
    public Text qtdPotuacao;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        vidaBar.fillAmount = player.health/5;
        qtdVida.text = player.health.ToString();
        qtdPotuacao.text = player.pontuacao.ToString();
    }
}
