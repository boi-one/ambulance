using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    Image timerBar;
    float percentage = 1f;
    void Awake()
    {
        timerBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (percentage > 0) percentage -= 0.1f * Time.deltaTime;
        timerBar.fillAmount = percentage;
    }
}
