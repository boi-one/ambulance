using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    public PatientManager manager;
    public Player player;
    bool saved = false;
    bool alive = true;
    public UITimer timer;

    // Start is called before the first frame update
    void Start()
    {
        player = manager.player;
        timer = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<UITimer>();
        timer.speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (!Input.GetKey(KeyCode.E) && !saved) timer.DecreaseTimer();
        if (distance < 1 && !player.carrying)
        {
            if (Input.GetKey(KeyCode.E)) timer.IncreaseTimer(); //TODO: continue working on this

            if (timer.percentage >= 1) saved = true;
            if (saved)
            {
                transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                player.carrying = true;
                transform.SetParent(manager.player.gameObject.transform.GetChild(0));
                transform.position = transform.parent.transform.position + (player.gameObject.transform.right * 0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                manager.allPatients.Remove(gameObject);
            }
        }

        if (timer.percentage < 0)
        {
            alive = false;
            manager.allPatients.Remove(gameObject);
        }
    }
}
