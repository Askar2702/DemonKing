using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab; // Префаб объекта, который нужно создать
    [SerializeField] private int _numberOfObjects = 10; // Количество объектов для создания
    [SerializeField] private GameObject _planeObject; // 3D объект Plane, внутри которого будут спавниться объекты

    private Bounds _spawnBounds; // Границы объекта Plane

    private void Start()
    {
        // Получаем границы объекта Plane
        Renderer planeRenderer = _planeObject.GetComponent<Renderer>();
        _spawnBounds = planeRenderer.bounds;

        for (int i = 0; i < _numberOfObjects; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        // Вычисляем случайные координаты для спавна объекта внутри границ объекта Plane
        Vector3 spawnPosition = GetRandomPositionWithinBounds();

        // Создаем новый объект из префаба и устанавливаем его позицию
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

