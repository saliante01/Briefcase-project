using JSG.Project_Pinball.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas
using UnityEngine.UI;  // Necesario para trabajar con los botones

public class MenuController : MonoBehaviour
{
    public DataStorage dataStorage;
    // Función para cargar la escena llamada "1"
    public void PlayGame()
    {
        // Cargar la escena "1"
        dataStorage.LevelNumber = 1;
        SceneManager.LoadScene("1");
        
    }

    // Función para salir del juego
    public void ExitGame()
    {
        // Imprimir un mensaje en consola (opcional)
        Debug.Log("Saliendo del juego...");

        // Salir del juego
        Application.Quit();

        // En el editor de Unity, esto no cerrará la aplicación, pero puedes simularlo con:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // No es necesario el código adicional aquí, Application.Quit() cierra la aplicación en el build
#endif
    }
}
