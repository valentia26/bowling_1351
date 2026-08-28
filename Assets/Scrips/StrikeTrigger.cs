using UnityEngine;

public class StrikeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            BowlingScoreManager.instance.CheckStrike();
        }
    }
}