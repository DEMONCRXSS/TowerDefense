using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider _healthSlider;
    [SerializeField]
    private float _maxHealth = 100f;
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;
    [SerializeField]
    private UnityEvent<float> _onTakeDamage;
    [SerializeField]
    private UnityEvent _onDie;
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _onTakeDamage.Invoke(damage);
        if (_currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthSlider();
    }
    public void Die()
    {
        _currentHealth = 0;
        _onDie.Invoke();
    }
    public void InitializeHealth()
    {
        _currentHealth = _maxHealth;
        UpdateHealthSlider();
    }
    private void UpdateHealthSlider()
    {
        _healthSlider.value = _currentHealth / _maxHealth;
    }
}
