using UnityEngine;

public class SpeedDownTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //---------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        gameManager.SpeedDownTrigger(this);
    }
}
