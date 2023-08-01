using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    // Referencia estática a sí mismo para crear un patrón Singleton
    public static BackgroundMusicManager instance;

    // AudioSource para reproducir la música de fondo
    private AudioSource audioSource;

    // La música de fondo que deseas reproducir (asegúrate de agregar la música en el componente AudioSource del objeto)
    public AudioClip backgroundMusic;

    // Variable para almacenar la escena en la que se inició la reproducción del sonido
    private string initialScene;

    private void Awake()
    {
        // Configurar el patrón Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Reproducir la música de fondo si no está reproduciéndose
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }

        // Obtener la escena inicial
        initialScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        // Obtener la escena actual
        string currentScene = SceneManager.GetActiveScene().name;

        // Si la escena ha cambiado y no es la escena inicial, detener y reproducir la música nuevamente
        if (currentScene != initialScene && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
