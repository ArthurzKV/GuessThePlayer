using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anuncio : MonoBehaviour
{
    public AdsManager adManager;
    
    // Start is called before the first frame update
    void Start()
    {
        adManager.LoadInterstitialAd();
        StartCoroutine(ShowAdAfterDelay(1f)); // Espera 1 segundo antes de mostrar el anuncio
    }

    // Método para mostrar el anuncio después de un retraso
    private IEnumerator ShowAdAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        adManager.ShowAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
