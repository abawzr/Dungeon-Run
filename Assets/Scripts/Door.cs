using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private TMP_Text objectiveText;

    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerInventory.HasKey && !_isTriggered)
            {
                _isTriggered = true;
                key.SpawnKey();
                objectiveText.text = "Objective: Find the key";
            }

            else if (playerInventory.HasKey)
            {
                Debug.Log("You Escaped!");
            }
        }
    }
}
