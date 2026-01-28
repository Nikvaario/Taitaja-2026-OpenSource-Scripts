using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    [SerializeField] float remainingTimer = 1800.0f;
    [SerializeField] private bool timerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (remainingTimer <= 0f)
        {
            timerRunning = false;
        }

        if (timerRunning)
        {
            remainingTimer -= Time.deltaTime;
            DisplayTimer(remainingTimer);
        }
    }

    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
