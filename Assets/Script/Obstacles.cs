using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Obstacles : MonoBehaviour
{

    // ================= Initialize ========================
    private GameManager gameManager;
    private Player player;
    [SerializeField] private float moveSpeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
        player = Player.Instance;
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
            player.Die();
            Debug.Log("Player Die");
        }        
    }

}
