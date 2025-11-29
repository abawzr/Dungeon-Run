using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private TMP_Text objectiveText;

    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();

        StartCoroutine(StopRigidbody());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInventory.HasKey = true;

            _audioSource.PlayOneShot(pickupClip);
            Destroy(gameObject, pickupClip.length);
            objectiveText.text = "Objective: Use the key to escape";
        }
    }

    private IEnumerator StopRigidbody()
    {
        yield return new WaitForSeconds(2f);
        _rigidbody.isKinematic = true;

        yield return new WaitForSeconds(1f);
        _boxCollider.isTrigger = true;
    }

    public void SpawnKey()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);

        transform.position = spawnPoints[randomIndex].position;

        gameObject.SetActive(true);
    }
}
