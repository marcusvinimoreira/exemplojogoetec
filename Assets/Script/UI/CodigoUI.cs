using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CodigoUI : MonoBehaviour
{
    public Text txt;
    private int numero;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {        
      
    }

   public void BtnEvento()
    {
        numero++;
        txt.text = numero.ToString();
    }
}
