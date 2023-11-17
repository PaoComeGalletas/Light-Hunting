using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzIntermitente : MonoBehaviour
{
    private Light luz;
    public float velocidadIntermitencia = 2.0f;
    private float intensidadBase;

    void Start()
    {
       luz = GetComponent<Light>();
        intensidadBase = luz.intensity; 
    }

    // Update is called once per frame
    void Update()
    {
      float factor = Mathf.PingPong(Time.time * velocidadIntermitencia, 1.0f);
        luz.intensity = intensidadBase * factor;  
    }
}
