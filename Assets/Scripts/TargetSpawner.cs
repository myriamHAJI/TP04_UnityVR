using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float spawnInterval = 3f;
    public float targetLifetime = 5f;

    public float minX = -2f;
    public float maxX = 2f;

    public float minY = 0.8f;
    public float maxY = 2f;

    public float spawnZ = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 1f, spawnInterval);
    }

    private void SpawnTarget()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            spawnZ
        );

        GameObject newTarget = Instantiate(
            targetPrefab,
            randomPosition,
            Quaternion.identity
        );

        Destroy(newTarget, targetLifetime);
    }
}