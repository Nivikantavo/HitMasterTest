using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSetter : MonoBehaviour
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private GameObject HealthViewerPrefab;
    private Enemy[] _enemies;

    private void Awake()
    {
        _enemies = FindObjectsOfType<Enemy>();

        foreach (var enemy in _enemies)
        {
            SetHealthBar(enemy);
        }
    }

    private void SetHealthBar(Enemy enemy)
    {
        HealthViewer healthViewer = Instantiate(HealthViewerPrefab, _conteiner).GetComponent<HealthViewer>();
        healthViewer.SetTarget(enemy);
    }
}
