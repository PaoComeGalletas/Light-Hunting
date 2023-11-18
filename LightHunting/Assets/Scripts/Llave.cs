using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Llave : MonoBehaviour
{

    public GameObject alerta;
    public string textoAlerta = "Press E to take the Key";
    public string clave="global";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            alerta.GetComponent<Text>().text = textoAlerta.ToString();
            alerta.gameObject.SetActive(true);
            if (Input.GetKey("e")){
                other.GetComponent<Inventario>().llaves.Add(clave);
                alerta.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            alerta.gameObject.SetActive(false);
        }
    }
}

