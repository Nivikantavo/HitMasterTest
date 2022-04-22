using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public int AliveEnemy => _enemies.Count;

    [SerializeField] private List<Enemy> _enemies;

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDied += OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.EnemyDied -= OnEnemyDied;
    }
}
