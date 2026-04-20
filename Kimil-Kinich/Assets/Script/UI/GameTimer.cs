using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public bool isRunning = true;

    public PlayerHealth playerHealth;

    [Header("UI")]
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 10)
		{
    		timerText.color = Color.red;
		}
		else
		{
    		timerText.color = Color.white;
		}

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isRunning = false;

            playerHealth.TakeDamage(999);
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float extraTime)
    {
        timeRemaining += extraTime;
    }
}