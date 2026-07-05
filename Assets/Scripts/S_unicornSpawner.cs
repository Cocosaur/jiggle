using UnityEngine;

public class S_unicornSpawner : MonoBehaviour
{

    public S_unicornCollector uniCollector;
    public int additionalSpawnCount = 2;
    public S_unicornMovement spawnObject;
    public float spawnOffset;
    void SpawningUnicorns()
    {
        for (int i = 0; i < uniCollector.unicornObjective+additionalSpawnCount; i++)
        {
            S_unicornMovement _unicorn = Instantiate(spawnObject, transform.position + Vector3.right * i *spawnOffset ,Quaternion.identity);
            _unicorn.collector = uniCollector;
        }
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawningUnicorns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
