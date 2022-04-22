using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Animator _animator;

    private int _currentHealth;

    public event UnityAction<Enemy> EnemyDied;
    public event UnityAction<int, int> HealthChange;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            _currentHealth -= damage;
            HealthChange?.Invoke(_currentHealth, _maxHealth);

            if(_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        _animator.enabled = false;
        EnemyDied?.Invoke(this);
    }
}
