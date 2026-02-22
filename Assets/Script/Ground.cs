using UnityEngine;

public class Ground : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = Player.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Die");
            player.Die();
        }        
    }
}
