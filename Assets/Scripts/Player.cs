using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audio;
    
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _audioClips[0];
        _audio.loop = true;
        _audio.Play();
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bomb bomb))
        {
            PlayDieSound();
            Time.timeScale = 0;
            Destroy(gameObject, 1f);
        }
    }

    private void PlayDieSound()
    {
        _audio.Stop();
        _audio.loop = false;
        _audio.clip = _audioClips[1];
        _audio.Play();
    }
}