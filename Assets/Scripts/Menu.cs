using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] clips;

    bool canPlayAudio = true;

    void Start()
    {
        StartCoroutine(PlayAudio());
    }



    IEnumerator PlayAudio()
    {
        while(canPlayAudio)
        {
            Debug.Log("audio start");
            yield return new WaitForSeconds(4f);

            audioSource.clip = clips[0];
            audioSource.Play();

            yield return new WaitForSeconds(9f);

            audioSource.clip = clips[1];
            audioSource.Play();
        }
    }

    public void OnPressContinue()
    {
        canPlayAudio = false;
        audioSource.Stop();
        SceneManager.LoadScene("Main");
    }
}
