using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 3f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            float randomY = Random.Range(-1f, 3f);
            Instantiate(pipePrefab, new Vector3(6, randomY, 0), Quaternion.identity);
            timer = 0;
        }
    }
}
