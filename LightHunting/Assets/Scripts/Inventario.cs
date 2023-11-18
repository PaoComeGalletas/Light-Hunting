using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> llaves = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AgregarLlave(string llave){
        llaves.Add(llave);
    }
}
