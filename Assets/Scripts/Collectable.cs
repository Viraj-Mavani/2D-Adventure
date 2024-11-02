using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (CompareTag("Coin"))
                LevelManager.Instance.AddCoins(value);
            else if (CompareTag("Key"))
                LevelManager.Instance.AddKey();

            Destroy(gameObject);
        }
    }
}
