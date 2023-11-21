using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hablar : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource { get {return GetComponent<AudioSource>();}}
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if (!audioSource.isPlaying)
            audioSource.PlayOneShot(clip);
        }
    }
}
