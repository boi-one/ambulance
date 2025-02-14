using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    Image timerBar;
    public float percentage
    {
        get
        {
            return _percentage;
        }
    } float _percentage = 1f;
    void Awake()
    {
        timerBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timerBar.fillAmount = _percentage;
    }

    public void DecreaseTimer()
    {
        if (_percentage > 0) _percentage -= 0.01f * Time.deltaTime;
    }

    public void IncreaseTimer()
    {
        if (_percentage < 1) _percentage += 0.01f * Time.deltaTime;
    }
}
