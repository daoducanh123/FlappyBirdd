using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    private GameManager gameManager;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
        player = Player.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            Debug.Log("Score++");
            gameManager.AddScore(1);
        }    
    }
}
