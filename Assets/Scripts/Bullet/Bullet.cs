using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PartOfHitBox>(out PartOfHitBox enemyHitBox))
        {
            enemyHitBox.HitEnemy(_damage);
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }
}
