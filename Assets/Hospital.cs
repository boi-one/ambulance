using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public int patients = 0;
    [SerializeField]
    TMP_Text dropNotification;
    [SerializeField]
    TMP_Text patientCounter;

    private void Awake()
    {
        dropNotification.gameObject.SetActive(false);
    }

    void Update()
    {
        patientCounter.text = $"People saved: {patients}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.parked = true;
        direction.sprite = dropPatient;
        direction.transform.rotation = Quaternion.identity;
        dropNotification.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (Input.GetKeyDown(KeyCode.Return) && player.carrying)
        {
            Debug.Log("Delivered");
            player.carrying = false;
            Destroy(player.transform.GetChild(0).transform.GetChild(0).gameObject);
            patients++;
            //TODO: fix arrow so it points to the hospital
            //make a timer when picking up a patient
            //carry only 1 person at a time
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.parked = false;
        direction.sprite = originalDirection;
        dropNotification.gameObject.SetActive(false);
    }
}
