using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ContinueTalking()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
