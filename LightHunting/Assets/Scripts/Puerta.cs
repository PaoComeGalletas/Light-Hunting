using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puerta : MonoBehaviour
{
    public float AngleY = 90.0f;
    private float targetValue = 0.0f;
    private float currentValue = 0.0f;
    private float easing = 0.05f;
    public string clave="global";
    public GameObject target;
    public GameObject alerta;
    public string textoAlerta = "The door is locked";
    private bool cerrada = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = currentValue+(targetValue-currentValue)*easing;
        target.transform.rotation = Quaternion.identity;
        target.transform.Rotate (0,currentValue,0);
    }
    private void OnTriggerStay(Collider other) {
        if (cerrada)
        if (other.gameObject.tag == "Player")
        {
            alerta.gameObject.SetActive(true);
            if (other.GetComponent<Inventario>().llaves.Contains(clave))
            {
                textoAlerta = "Press E to open the door";
                if (Input.GetKey("e")){
                    targetValue = AngleY;
                    currentValue = 0.0f;
                    other.GetComponent<Inventario>().llaves.Remove(clave);
                    cerrada = false;
                    alerta.gameObject.SetActive(false);
                }
            }
            alerta.GetComponent<Text>().text = textoAlerta.ToString();
            
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            alerta.gameObject.SetActive(false);
        }
    }
}
