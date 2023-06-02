using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab; // ������ �������, ������� ����� �������
    [SerializeField] private int _numberOfObjects = 10; // ���������� �������� ��� ��������
    [SerializeField] private GameObject _planeObject; // 3D ������ Plane, ������ �������� ����� ���������� �������

    private Bounds _spawnBounds; // ������� ������� Plane

    private void Start()
    {
        // �������� ������� ������� Plane
        Renderer planeRenderer = _planeObject.GetComponent<Renderer>();
        _spawnBounds = planeRenderer.bounds;

        for (int i = 0; i < _numberOfObjects; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        // ��������� ��������� ���������� ��� ������ ������� ������ ������ ������� Plane
        Vector3 spawnPosition = GetRandomPositionWithinBounds();

        // ������� ����� ������ �� ������� � ������������� ��� �������
        GameObject newObject = Instantiate(_objectPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomPositionWithinBounds()
    {
        float randomX = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
        float randomY = Random.Range(_spawnBounds.min.y, _spawnBounds.max.y);
        float randomZ = Random.Range(_spawnBounds.min.z, _spawnBounds.max.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}

