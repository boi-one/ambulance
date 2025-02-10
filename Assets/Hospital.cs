using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
    [SerializeField]
    Player player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return) && player.carying)
        {
            player.carying = false;
            Debug.Log("Delivered");
            //TODO: fix arrow so it points to the hospital
            //when at the hospital parking change arrow to '!'
            //make a timer when picking up a patient
            //carry only 1 person at a time
        }
    }
}
