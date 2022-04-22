using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class HitBox : MonoBehaviour
{
    private Enemy _enemy;
    private CapsuleCollider[] _hitBox;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _hitBox = GetComponentsInChildren<CapsuleCollider>();

        foreach (var collider in _hitBox)
        {
            PartOfHitBox partOfHitBox = collider.gameObject.AddComponent<PartOfHitBox>();
            partOfHitBox.Hit += OnEnemtHit;
        }
    }

    private void OnEnemtHit(int damage)
    {
        _enemy.TakeDamage(damage);
    }
}
