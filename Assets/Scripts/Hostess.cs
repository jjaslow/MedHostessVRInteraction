using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hostess : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject canvasPanel;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] clips;


    string[] results = new string[]
    {
        "I'm glad you are feeling well. Why are you here then?",
        "Take 2 aspirin and see me in the morning.",
        "Let's get you to the ICU right away!"
    };

    private void Start()
    {
        canvasPanel.SetActive(false);
    }

    public void StartTalking()
    {
        Debug.Log("talking");
        canvasPanel.SetActive(true);

        transform.LookAt(player.transform.position);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y , 0);

        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void ContinueTalking(Text text, int number)
    {
        text.text = results[number];

        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
