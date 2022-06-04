using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private AudioMixerGroup _mixer;


    private readonly Vector3 _position = new Vector3(0f, -3.863f, 0f);
    private GameObject _player;
    private AudioSource _audio;
    private bool _audioPlay;
    private string _masterVolume = "MasterVolume";
    private string _playerVolume = "PlayerVolume";

    private void Start()
    {
         Time.timeScale = 0;
        _audio = GetComponent<AudioSource>();
        _audio.loop = true;
        _audio.Play();
    }

    public void OpenPanel()
    {
        _scorePanel.SetActive(false);
        _pauseButton.SetActive(false);
        _audio.Play();
        _audio.loop = true;
        _menuPanel.SetActive(true);
        _mixer.audioMixer.SetFloat(_playerVolume, -80f);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        _audio.Stop();
        _menuPanel.SetActive(false);
        _mixer.audioMixer.SetFloat(_playerVolume, 0f);
        Time.timeScale = 1;
        _scorePanel.SetActive(true);
        _pauseButton.SetActive(true);

        if (_player == null)
        {
            SpawnPlayer();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        _audioPlay = !_audioPlay;

        SoundOn();
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab, _position, quaternion.identity);
    }

    private void SoundOn()
    {
        if (!_audioPlay)
        {
            _mixer.audioMixer.SetFloat(_masterVolume, 0);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_masterVolume, -80f);
        }
    }
    
}