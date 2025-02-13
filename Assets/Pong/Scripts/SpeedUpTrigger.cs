using UnityEngine;

public class SpeedUpTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //---------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Ensure it only affects the ball
        {
            gameManager.SpeedUpTrigger();
        }
    }
}
