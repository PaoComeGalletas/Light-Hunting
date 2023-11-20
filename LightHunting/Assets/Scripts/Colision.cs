using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colision : MonoBehaviour
{
     public GameObject txtGem;
    private int gem;
    public GameObject txtKey;
    private int key;
    public AudioSource audioSource {get{return GetComponent<AudioSource>();}}
    public AudioClip clipGem;
    public AudioClip clipKey;
   

    void Start()
    {
        gameObject.AddComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider objeto){
        
        if(objeto.gameObject.tag=="Gem"){
         Destroy(objeto.gameObject);
         audioSource.PlayOneShot(clipGem);
         gem+=1;
         txtGem.GetComponent<Text>().text=gem.ToString();   
        }

        if(objeto.gameObject.tag=="Key"){
         Destroy(objeto.gameObject);
         audioSource.PlayOneShot(clipKey);
         key+=1;
         txtKey.GetComponent<Text>().text=key.ToString();   
        }
        
    }
}
