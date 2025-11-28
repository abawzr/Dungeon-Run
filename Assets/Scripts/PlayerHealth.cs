using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthBarSlider;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = _currentHealth;
    }

    private void Die()
    {
        Debug.Log("Player Dead");
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        healthBarSlider.value = _currentHealth;

        if (_currentHealth <= 0f)
        {
            Die();
        }
    }
}
