using System;
using UnityEngine;
using UnityEngine.Events;

public class Background : MonoBehaviour
{
    public event UnityAction Bombed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bomb bomb))
        {
            Bombed?.Invoke();
        }
    }
}
