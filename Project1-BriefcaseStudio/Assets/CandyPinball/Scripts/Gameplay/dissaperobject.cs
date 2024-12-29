using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissaperobject : MonoBehaviour
{
    // Tiempo en segundos antes de desactivar el objeto
    public float delay;

    void Start()
    {
        // Invoca el método "DeactivateObject" después del tiempo especificado
        Invoke("DeactivateObject", delay);
    }

    // Método para desactivar el objeto
    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}