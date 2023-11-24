using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour
{
     public GameObject txtGem;
    private int gem;
    public GameObject txtKey;
    private int key;
    public GameObject txtMKey;
    private int Mkey;
    public AudioSource audioSource {get{return GetComponent<AudioSource>();}}
    public AudioClip clipGem;
    public AudioClip clipKey;
    public string textoAlertaKey = "Press E to take the Key";
    public string textoAlertaGem = "Press E to take the Gem";
    public string textoAlertaMKey = "Press E to take the Master Key";
    public GameObject alerta;
    public string clave="global";
    public GameObject gema3;


   

    void Start()
    {
        gameObject.AddComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider objeto){

        if(objeto.gameObject.tag=="Gem"){
            alerta.GetComponent<Text>().text = textoAlertaGem.ToString();
            alerta.gameObject.SetActive(true);

            if(Input.GetKey("e")){
                Destroy(objeto.gameObject);
                audioSource.PlayOneShot(clipGem);
                gem+=1;
                txtGem.GetComponent<Text>().text=gem.ToString();   
                alerta.gameObject.SetActive(false);

                if(gem >= 2){
                    gema3.SetActive(true);
                }
            }
        }

        if(objeto.gameObject.tag=="Key"){
            alerta.GetComponent<Text>().text = textoAlertaKey.ToString();
            alerta.gameObject.SetActive(true);

            if(Input.GetKey("e")){
                this.GetComponent<Inventario>().llaves.Add(clave);
                Destroy(objeto.gameObject);
                audioSource.PlayOneShot(clipKey);
                key+=1;
                txtKey.GetComponent<Text>().text=key.ToString(); 
                alerta.gameObject.SetActive(false);
            }  
        }

        if(objeto.gameObject.tag=="Master key" ){
            alerta.GetComponent<Text>().text = textoAlertaMKey.ToString();
            alerta.gameObject.SetActive(true);

            if(Input.GetKey("e")){
                this.GetComponent<Inventario>().llaves.Add("master key");
                Destroy(objeto.gameObject);
                audioSource.PlayOneShot(clipKey);
                Mkey+=1;
                txtMKey.GetComponent<Text>().text=Mkey.ToString(); 
                alerta.gameObject.SetActive(false);
            }  
        }

        if(objeto.gameObject.tag=="Final key" ){
            alerta.GetComponent<Text>().text = textoAlertaMKey.ToString();
            alerta.gameObject.SetActive(true);

            if(Input.GetKey("e")){
                this.GetComponent<Inventario>().llaves.Add("final key");
                Destroy(objeto.gameObject);
                audioSource.PlayOneShot(clipKey);
                Mkey+=1;
                txtMKey.GetComponent<Text>().text=Mkey.ToString(); 
                alerta.gameObject.SetActive(false);
            }  
        }

        if(objeto.gameObject.tag=="Final border"){
            Cursor.lockState = CursorLockMode.None; // Esto desbloquea el cursor
            Cursor.visible = true; // Esto hace que el cursor sea visible
            SceneManager.LoadScene("Win"); 
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Gem" || other.gameObject.tag == "Key" || other.gameObject.tag == "Master key")
        {
            alerta.gameObject.SetActive(false);
        }
    }

    public void restarLlave(){
        if (key >= 0){
            key -= 1;
            txtKey.GetComponent<Text>().text = Mkey.ToString();
        }
    }

    public void restarLlaveMaestra(){
        Mkey-=1;
        txtMKey.GetComponent<Text>().text=Mkey.ToString(); 
    }

    public int getGems(){return gem;}
}
