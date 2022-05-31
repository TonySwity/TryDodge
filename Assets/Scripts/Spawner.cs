using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _bombPrefab;
    
    private float _leftBound = -2.4f;
    private float _rightBound = 2.4f;

    private void Start()
    {
        Initialize(_bombPrefab);
        StartCoroutine(SpawnObject());
    }

    
    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        
        if (TryGetObject(out GameObject bomb))
        {
            SetEnemy(bomb, new Vector2(Random.Range(_leftBound, _rightBound),transform.position.y));
        }
    
        StartCoroutine(SpawnObject());
    }

    private void SetEnemy(GameObject bomb, Vector2 position)
    {
        bomb.SetActive(true);
        bomb.transform.position = position;
    }
}
