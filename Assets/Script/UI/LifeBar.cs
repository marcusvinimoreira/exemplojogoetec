using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image vidaBar;
    public Text txtVida;
    public int valorAtual = 100;
    public int dano = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dano()
    {
        if (valorAtual > 0)
        {
            valorAtual -= dano;
            vidaBar.fillAmount = (float)valorAtual / 100;
            txtVida.text = valorAtual.ToString();
        }
    }
}
