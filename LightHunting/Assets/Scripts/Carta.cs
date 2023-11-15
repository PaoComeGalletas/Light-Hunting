using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Carta : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject carta;
    public GameObject cartaTexto;
    public GameObject alerta;

    public string texto;
    public string textoAlerta;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("cartaaa");
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            alerta.GetComponent<Text>().text = textoAlerta.ToString();
            alerta.gameObject.SetActive(true);
            if (Input.GetKeyDown("e")){
                cartaTexto.GetComponent<Text>().text = texto.ToString();
                carta.gameObject.SetActive(!carta.gameObject.activeSelf);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            alerta.gameObject.SetActive(false);
            carta.gameObject.SetActive(false);
        }
    }
}
