using System;
using Unity.Mathematics;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _panel;

    private readonly Vector3 _position = new Vector3(0f, -3.863f, 0f);
    private GameObject _player;
    
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;

        if (_player == null)
        {
            SpawnPlayer();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab, _position, quaternion.identity);
    }
}