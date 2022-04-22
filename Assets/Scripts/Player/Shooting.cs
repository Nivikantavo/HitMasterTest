using UnityEngine;

public class Shooting : BulletPull
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootingDistance;

    private void Awake()
    {
        Initialize(_bulletPrefab);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(TryGetObject(out _bulletPrefab))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Vector3 direction;

            if (Physics.Raycast(ray, out hitInfo, _shootingDistance, 1))
            {
                direction = hitInfo.point;
            }
            else
            {
                direction = _camera.ScreenPointToRay(Input.mousePosition).GetPoint(_shootingDistance);
            }

            SetBullet(_bulletPrefab, direction);
        }
    }

    private void SetBullet(GameObject bullet, Vector3 direction)
    {
        bullet.transform.position = _shootPoint.position;
        bullet.SetActive(true);
        bullet.transform.LookAt(direction);
    }
}
