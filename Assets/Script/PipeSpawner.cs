using UnityEngine;
using Unity.Collections;
using System.Collections;
public class PipeSpawner : MonoBehaviour
{
    private Player player; private PipePooling pipePooling;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnTimeInterval = 2.5f;
    [SerializeField] private float spawnRange = 2.5f;



    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.Instance;
        pipePooling = PipePooling.Instance;
        StartCoroutine(SpawnPipe());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnPipe()
    {
        while (player != null)
        {
            yield return new WaitForSeconds (spawnTimeInterval);
            float spawnOffset = Random.Range(-spawnRange, spawnRange);
            Vector2 spawnPos = (Vector2) transform.position + new Vector2 (0, spawnOffset);

            // SpawnPipe
            GameObject pipeSpawn = pipePooling.GetPipe();
            pipeSpawn.transform.position = spawnPos;
            Invoke(nameof(DeactivatePipe), 7f);
        }
    }

    private void DeactivatePipe( )
    {
        pipePooling.ReturnPipe(gameObject);
    }
}
