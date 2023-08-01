using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

    private string lastSceneName;
    public string lastScene;

    public static PersistentObject Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PersistentObject>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para guardar el nombre de la última escena jugada en las PlayerPrefs
    public void SaveLastSceneName(string sceneName)
    {
        lastSceneName = sceneName;
        PlayerPrefs.SetString("LastScene", lastSceneName);
        PlayerPrefs.Save();
    }

    // Método para cargar la última escena guardada en las PlayerPrefs
    public void LoadLastScene()
    {
        lastScene = PlayerPrefs.GetString("LastScene", "MainMenu");
        SceneManager.LoadScene(lastScene);
    }
}
