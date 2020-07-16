using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostess : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject player;

    bool startedTalking = false;

    public void OnHover()
    {
        Debug.Log("pointing at: " + gameObject.name);
    }

    public void OnClick()
    {
        if(!startedTalking)
            StartTalking();
    }



    public void StartTalking()
    {
        Debug.Log("talking");
        startedTalking = true;
        transform.LookAt(player.transform.position);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y , 0);
    }
}
