using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    Image direction;
    [SerializeField]
    Sprite dropPatient;
    [SerializeField]
    Sprite originalDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.parked = true;
        player.carrying = false;
        direction.sprite = dropPatient;
        direction.transform.rotation = Quaternion.identity;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (Input.GetKeyDown(KeyCode.Return) && player.carrying)
        {
            Debug.Log("Delivered");
            //TODO: fix arrow so it points to the hospital
            //when at the hospital parking change arrow to '!'
            //make a timer when picking up a patient
            //carry only 1 person at a time
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.parked = false;
        direction.sprite = originalDirection;
    }
}
