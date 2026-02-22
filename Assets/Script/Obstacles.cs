using UnityEngine;

public class Obstacles : MonoBehaviour
{

    // ================= Initialize ========================
    [SerializeField] private float moveSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();       
    }

    private void MoveToPlayer()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Die");
        }        
    }
}
