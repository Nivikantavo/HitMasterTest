using UnityEngine;
using UnityEngine.Events;

public class PartOfHitBox : MonoBehaviour
{
    public event UnityAction<int> Hit;

    public void HitEnemy(int damage)
    {
        Hit?.Invoke(damage);
    }
}
