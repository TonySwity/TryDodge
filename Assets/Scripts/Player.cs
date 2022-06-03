using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Died;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bomb bomb))
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}