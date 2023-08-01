using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static bool isFirstTimePlaying = true;

    private void Start()
    {
        //  PlayerPrefs.DeleteAll();
        // Verificar si es la primera vez que se inicia el juego
        if (isFirstTimePlaying)
        {
            // Cargar el MainMenu solo en la primera ejecución
            isFirstTimePlaying = false;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayGame()
    {
        // Obtener el nombre de la última escena visitada desde PlayerPrefs
        string lastScene = PlayerPrefs.GetString("LastScene", "Cristiano Ronaldo");

        // Cargar la última escena visitada o el primer nivel si no hay información guardada
        SceneManager.LoadScene(lastScene);
    }
}
