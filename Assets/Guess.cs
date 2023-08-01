using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guess : MonoBehaviour
{
    public string input;
    public string player;
    public string player2;
    public string player3;
    public bool alive = true;
    public AdsManager adManager;
    public ScoreManager scoreManager;
    public AudioSource audioSource;
    public AudioClip correctSound;
    public Verifier verificar;
    public string escena;

    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        PersistentObject.Instance.SaveLastSceneName(currentSceneName);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        input = s.ToUpper();
        Debug.Log(input);

        if (input == player || input == player2 || input == player3)
        {
            Debug.Log("god");
            scoreManager.IncreaseScore(1);
            audioSource.PlayOneShot(correctSound);
            StartCoroutine(WaitAndLoadScene(1.5f)); // Espera 2 segundos antes de cambiar de escena
            verificar.Open();
        }
        else
        {
            alive = false;
            adManager.LoadInterstitialAd();
            adManager.ShowAd();
            Debug.Log("Pendejo");
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(escena, LoadSceneMode.Single);
    }
}
