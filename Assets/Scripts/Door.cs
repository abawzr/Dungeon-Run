using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private PlayerInventory playerInventory;

    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerInventory.HasKey && !_isTriggered)
            {
                _isTriggered = true;
                key.SpawnKey();
                Debug.Log("You need the key to escape");
            }

            else if (playerInventory.HasKey)
            {
                Debug.Log("You Escaped!");
            }
        }
    }
}
