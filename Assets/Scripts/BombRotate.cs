using UnityEngine;
using Random = UnityEngine.Random;

public class BombRotate : MonoBehaviour
{
    private float _angleZ;

    private void Start()
    {
        _angleZ = Random.Range(-90f, 90f);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0,0, _angleZ * Time.deltaTime);
    }
}
