using UnityEngine;

public class IntermitenciaLuz : MonoBehaviour
{
    private Light luz;
    public float velocidadIntermitencia = 2.0f;
    private float intensidadBase;

    void Start()
    {
        luz = GetComponent<Light>();
        intensidadBase = luz.intensity;
    }

    void Update()
    {
        float factor = Mathf.PingPong(Time.time * velocidadIntermitencia, 1.0f);
        luz.intensity = intensidadBase * factor;
    }
}