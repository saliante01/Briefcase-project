using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectLeft : MonoBehaviour
{
    // Configuración para el primer objeto
    public Transform targetObject; // Objeto que se mueve a la derecha
    public float moveDistance = 5f; // Distancia de movimiento a la derecha
    public float moveSpeed = 2f;   // Velocidad del movimiento

    // Configuración para el segundo objeto
    public Transform secondTargetObject; // Objeto que se mueve a la izquierda
    public float secondMoveDistance = 5f; // Distancia de movimiento a la izquierda
    public float secondMoveSpeed = 2f;    // Velocidad del movimiento

    // Variables privadas
    private Vector3 initialPosition;      // Posición inicial del primer objeto
    private Vector3 secondInitialPosition; // Posición inicial del segundo objeto
    private bool movingRight = true;      // Dirección del movimiento para el primer objeto
    private bool movingLeft = true;       // Dirección del movimiento para el segundo objeto

    void Start()
    {
        // Validar que se asignaron los objetos
        if (targetObject == null)
        {
            Debug.LogError("No se asignó un objeto para el movimiento a la derecha.");
            return;
        }

        if (secondTargetObject == null)
        {
            Debug.LogError("No se asignó un objeto para el movimiento a la izquierda.");
            return;
        }

        // Guardar las posiciones iniciales
        initialPosition = targetObject.position;
        secondInitialPosition = secondTargetObject.position;
    }

    void Update()
    {
        // Mover el primer objeto (a la derecha y de vuelta)
        if (targetObject != null)
        {
            MoveRightAndBack();
        }

        // Mover el segundo objeto (a la izquierda y de vuelta)
        if (secondTargetObject != null)
        {
            MoveLeftAndBack();
        }
    }

    void MoveRightAndBack()
    {
        Vector3 targetPosition = initialPosition + Vector3.right * moveDistance;

        if (movingRight)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(targetObject.position, targetPosition) < 0.01f)
            {
                movingRight = false;
            }
        }
        else
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, initialPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(targetObject.position, initialPosition) < 0.01f)
            {
                movingRight = true;
            }
        }
    }

    void MoveLeftAndBack()
    {
        Vector3 targetPosition = secondInitialPosition + Vector3.left * secondMoveDistance;

        if (movingLeft)
        {
            secondTargetObject.position = Vector3.MoveTowards(secondTargetObject.position, targetPosition, secondMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(secondTargetObject.position, targetPosition) < 0.01f)
            {
                movingLeft = false;
            }
        }
        else
        {
            secondTargetObject.position = Vector3.MoveTowards(secondTargetObject.position, secondInitialPosition, secondMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(secondTargetObject.position, secondInitialPosition) < 0.01f)
            {
                movingLeft = true;
            }
        }
    }
}