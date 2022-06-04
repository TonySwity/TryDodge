using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(BoxCollider2D), typeof(AudioSource))]
public class Bomb : MonoBehaviour
{
    private AudioSource _boomSound;
    private Animator _animator;
    private BoxCollider2D _collider;
    private float _delay = 1f;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _boomSound = GetComponent<AudioSource>();
        _boomSound.pitch = Random.Range(0.7f, 1.1f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _boomSound.Play();
        StartCoroutine(Bang());
        
        _animator.CrossFade(BombAnimationController.Params.Boom,0.1f);
        
        _collider.enabled = false;

    }

    private IEnumerator Bang()
    {
        yield return new WaitForSeconds(_delay);
        _collider.enabled = true;
        gameObject.SetActive(false);
        StopCoroutine(Bang());
    }
}