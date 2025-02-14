using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    public PatientManager manager;
    public Player player;
    bool saved = false;
    public UITimer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = manager.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        if(distance < 1 && Input.GetKeyDown(KeyCode.E) && !player.carrying)
        {
            player.carrying = true;
            transform.parent = manager.player.gameObject.transform.GetChild(0);
            transform.position = transform.parent.transform.position + (player.gameObject.transform.right * 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            manager.allPatients.Remove(gameObject);
        }
    }
}
