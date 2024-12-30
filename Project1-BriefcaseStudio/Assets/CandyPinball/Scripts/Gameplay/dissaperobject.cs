using JSG.Project_Pinball.Gameplay;
using JSG.Project_Pinball.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissaperObject : MonoBehaviour
{
    // Tiempo en segundos antes de desactivar el objeto
    public float delay;

    // Referencia al DataStorage que contiene el nivel actual
    public DataStorage dataStorage;
    public GameObject imegen;
    void Start()
    {
        // Verifica si el nivel es 1
        if (dataStorage.LevelNumber == 1)
        {
            // Establece el retraso a 3 segundos
            delay = 3f;

            // Activa el objeto (por si no está activo)
            imegen.SetActive(true);

            // Invoca la desactivación después del retraso
            Invoke(nameof(DeactivateObject), delay);
        }
        else
        {
            // Si no es el nivel 1, desactiva el objeto inmediatamente
            imegen.SetActive(false);
        }
    }

    private void DeactivateObject()
    {
        // Desactiva el objeto
        imegen.SetActive(false);
    }
}
