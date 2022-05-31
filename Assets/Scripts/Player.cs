using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bomb bomb))
        {
            Destroy(gameObject);
        }
    }
}
