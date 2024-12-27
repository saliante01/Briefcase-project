using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBall : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 50f;

    // Ejes de rotación: ajusta los valores para rotar en el eje deseado
    public Vector3 rotationAxis = new Vector3(0, 1, 0); // Rotación en el eje Y por defecto

    void Update()
    {
        // Rotar el objeto en su propio eje
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.Self);
    }
}