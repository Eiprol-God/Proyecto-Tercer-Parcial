using UnityEngine;

public class TimePickup : MonoBehaviour
{
    public float timeToAdd = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameTimer timer = FindObjectOfType<GameTimer>();

            if (timer != null)
            {
                timer.AddTime(timeToAdd);
            }

            Destroy(gameObject);
        }
    }
}
