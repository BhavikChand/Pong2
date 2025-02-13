using UnityEngine;

public class SpeedUpTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //---------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        gameManager.SpeedUpTrigger(this);
    }
}
