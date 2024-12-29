using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalOcilator2 : MonoBehaviour
{
    // Objeto a mover
    public GameObject targetObject;

    // Distancia máxima para avanzar
    public float maxDistance = 5f;

    // Velocidad del movimiento
    public float speed = 2f;

    // Posición inicial del objeto
    private Vector3 initialPosition;

    // Dirección del movimiento (1 para avanzar, -1 para retroceder)
    private int direction = 1;

    void Start()
    {
        // Guardar la posición inicial
        if (targetObject != null)
        {
            initialPosition = targetObject.transform.position;
        }
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calcular la dirección del movimiento en diagonal hacia abajo e izquierda
            Vector3 diagonalMovement = new Vector3(-1, -1, 0).normalized * speed * Time.deltaTime * direction;

            // Mover el objeto
            targetObject.transform.position += diagonalMovement;

            // Calcular la distancia recorrida desde la posición inicial
            float traveledDistance = Vector3.Distance(initialPosition, targetObject.transform.position);

            // Cambiar dirección si se alcanza la distancia máxima
            if (traveledDistance >= maxDistance)
            {
                direction *= -1;
            }

            // Asegurarse de no exceder la distancia inicial al retroceder
            if (direction == -1 && traveledDistance <= 0.1f)
            {
                targetObject.transform.position = initialPosition;
                direction = 1;
            }
        }
    }
}