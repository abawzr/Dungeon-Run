using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private PlayerHealth playerHealth;

    private NavMeshAgent _navMeshAgent;
    private float distance;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(playerTransform.position);

        distance = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log(distance);
        if (distance <= 2f)
        {
            playerHealth.TakeDamage(20f * Time.deltaTime);
        }
    }
}
