using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light linternaSpotlight; 
    public AudioClip encenderSound; 
    public AudioClip apagarSound; 

    private AudioSource audioSource; 
    private bool encendida = true; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Verificar si hay un componente AudioSource adjunto
        if (audioSource == null)
        {
            // Si no hay uno, agregarlo al objeto
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegúrate de que la linterna comience encendida
        linternaSpotlight.enabled = true;
    }

    void Update()
    {
        // Verifica si se presiona la tecla para encender/apagar la linterna (en este caso la tecla L)
        if (Input.GetKeyDown(KeyCode.C))
        {
            

            // Reproduce el sonido correspondiente si los clips y el audioSource están disponibles
            if (audioSource != null)
            {
                if (encendida && encenderSound != null)
                {
                    audioSource.PlayOneShot(encenderSound);
                }
                else if (!encendida && apagarSound != null)
                {
                    audioSource.PlayOneShot(apagarSound);
                }
            }

            // Cambia el estado de la linterna y activa/desactiva el spotlight
            encendida = !encendida;
            linternaSpotlight.enabled = encendida;
        }
    }
}
