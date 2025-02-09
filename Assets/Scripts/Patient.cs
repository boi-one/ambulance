using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public PatientManager manager;
    public Player player;
    bool saved = false;
    // Start is called before the first frame update
    void Start()
    {
        player = manager.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        if(distance < 1 && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("saved");
            manager.allPatients.Remove(gameObject);
        }
    }
}
