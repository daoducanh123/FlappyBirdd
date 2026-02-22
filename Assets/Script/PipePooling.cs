using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;  

public class PipePooling : MonoBehaviour
{
    public static PipePooling Instance;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private int poolSize = 10;
    private Queue <GameObject> pool = new Queue <GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    
        for (int i = 0; i < poolSize; ++i)
        {
            GameObject pipe = Instantiate (pipePrefab, transform.position, Quaternion.identity);
            pipe.SetActive(false);
            pool.Enqueue(pipe);
        }

    }

    public GameObject GetPipe()
    {
        if (pool.Count > 0)
        {
            GameObject pipe = pool.Dequeue();
            pipe.SetActive(true);
            return  pipe;
        }
        else
        {
            Debug.Log("Pool empty");
            return null;
        }
    }

    public void ReturnPipe(GameObject pipe)
    {
        pipe.SetActive(false);
        pool.Enqueue(pipe);
    }



}
