using JSG.Project_Pinball.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotsAvailable : MonoBehaviour
{
    public DataStorage datastorage;

    void Start()
    {
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Ajusta el valor de Shots_available según el índice de la escena
        switch (currentSceneIndex)
        {
            case 1:
                datastorage.Shots_available = 1;
                break;
            case 2:
                datastorage.Shots_available = 2;
                break;
            case 3:
                datastorage.Shots_available = 3;
                break;
            case 4:
                datastorage.Shots_available = 3;
                break;
            default:
                Debug.LogWarning("Escena no configurada, usando valor por defecto de Shots_available.");
                datastorage.Shots_available = 0; // Valor por defecto si no está configurado
                break;
        }

        Debug.Log($"Shots_available set to: {datastorage.Shots_available}");
    }
}
