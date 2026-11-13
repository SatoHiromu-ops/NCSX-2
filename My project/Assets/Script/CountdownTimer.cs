
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float remainingTime = 169f;

    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                Debug.Log("TIME UP!");
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
