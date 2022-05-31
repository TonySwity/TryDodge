using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(BoxCollider2D))]
public class Bomb : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider2D _collider;
    private float _delay = 1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(Bang());
        if (col.gameObject.TryGetComponent(out Player player) || col.gameObject.TryGetComponent(out Ground ground) )
        {
            _animator.CrossFade("Boom",0.1f);
            _collider.enabled = false;
        }
       
    }

    private IEnumerator Bang()
    {
        yield return new WaitForSeconds(_delay);
        _collider.enabled = true;
        gameObject.SetActive(false);
        StopCoroutine(Bang());
    }
}