using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostess : MonoBehaviour
{
    [SerializeField]
    GameObject player;





    public void StartTalking()
    {
        Debug.Log("talking");
        transform.LookAt(player.transform.position);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y , 0);
    }
}
