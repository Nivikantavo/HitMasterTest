using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Image _background;

    private Enemy _target;
    private Slider _slider;

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
        _target.HealthChange += OnHealthChange;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnDisable()
    {
        _target.HealthChange -= OnHealthChange;
    }

    private void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(_target.transform.position + _offset);
    }

    private void OnHealthChange(int health, int maxHealth)
    {
        _slider.value = (float)health / maxHealth;

        if(_slider.value == 0)
        {
            StartCoroutine(HideBar());
        }
    }

    private IEnumerator HideBar()
    {
        WaitForFixedUpdate step = new WaitForFixedUpdate();
        int hideStep = 5;

        var color = _background.color;

        while (_background.color.a > 0)
        {
            color.a -= hideStep; 
            _background.color = color;

            yield return step;
        }
        gameObject.SetActive(false);
    }
}
