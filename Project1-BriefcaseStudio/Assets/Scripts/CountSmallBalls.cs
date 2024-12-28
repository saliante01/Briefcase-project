using JSG.Project_Pinball.Gameplay; // Asegúrate de tener el namespace correcto para GameControl
using UnityEngine;

public class CountSmallBalls : MonoBehaviour
{
    [SerializeField] // Esto lo hace visible en el Inspector
    private GameObject[] smallBalls;

    [SerializeField]
    public int smallBallCount;
    [SerializeField]
    public bool hasSpawnedSmallBalls = false; // Bandera para verificar si las small balls han aparecido

    public GameControl gameControl; // Referencia a la clase GameControl

    public Pusher pusherscript;

    public float cantidadrestante;

    public GameObject losspanel;
    void Start()
    {
        smallBallCount = smallBalls.Length;
        Debug.Log("Número inicial de objetos con el tag 'SmallBall': " + smallBallCount);

        // Asegurarnos de que tenemos una referencia a GameControl
        if (gameControl == null)
        {
            gameControl = FindObjectOfType<GameControl>(); // Buscamos el GameControl en la escena
            if (gameControl == null)
            {
                Debug.LogError("GameControl no encontrado en la escena. Asegúrate de que el objeto GameControl esté presente.");
            }
        }
    }

    void Update()
    {
        // Verificamos si el arreglo de smallBalls está vacío y las balls no han sido generadas
        if (!hasSpawnedSmallBalls)
        {
            smallBalls = GameObject.FindGameObjectsWithTag("smallball");

            // Si encontramos alguna small ball, entonces cambiamos la bandera
            if (smallBalls.Length > 0)
            {
                hasSpawnedSmallBalls = true;
                Debug.Log("Las Small Balls han aparecido.NO REAL");
            }
        }

        // Solo se cuenta y actualiza el número si las balls ya han aparecido
        if (hasSpawnedSmallBalls)
        {
            smallBalls = GameObject.FindGameObjectsWithTag("smallball");
            smallBallCount = smallBalls.Length;
            cantidadrestante = gameControl.NeededBalls - gameControl.CollectedCount;
            // Restamos el valor de 'colectedCount' de 'smallBallCount' en cada actualización
            if (gameControl != null)
            {
                smallBallCount -= gameControl.CollectedCount; // Restamos el colectedCount de smallBallCount
            }
            else
            {
                Debug.LogWarning("El objeto GameControl no está asignado. No se puede restar el 'CollectedCount'.");
            }

            // Verifica si el conteo llega a 0 después de que las small balls han aparecido
            if (smallBallCount <= 0 && pusherscript.shotavailable==0 && cantidadrestante!=0)
            {
                // Realiza alguna acción cuando el número de smallBalls llegue a 0
                Debug.Log("FALLO ");
                // Puedes agregar más acciones aquí si lo necesitas

                losspanel.SetActive(true);
            }

        }
    }
}
