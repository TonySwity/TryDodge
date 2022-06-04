using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator),typeof(BoxCollider2D), typeof(AudioSource))]
public class Bomb : MonoBehaviour
{
    private AudioSource _audio;
    private Animator _animator;
    private BoxCollider2D _collider;
    private float _delay = 1f;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _audio.Play();
        StartCoroutine(Bang());
        
        if (col.gameObject.TryGetComponent(out Player player))
        {
            _animator.CrossFade("Boom",0.1f);
            _collider.enabled = false;
        }

        if (col.gameObject.TryGetComponent(out Background ground))
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