using UnityEngine;

public class S_unicornSpawner : MonoBehaviour
{

    public S_unicornCollector uniCollector;
    public int additionalSpawnCount = 2;
    public GameObject spawnObject;
    public float spawnOffset;
    void SpawningUnicorns()
    {
        for (int i = 0; i < uniCollector.unicornObjective+additionalSpawnCount; i++)
        {
            Instantiate(spawnObject, transform.position + Vector3.right * i *spawnOffset ,Quaternion.identity);    
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
