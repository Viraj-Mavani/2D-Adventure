using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] Text coinText;
    [SerializeField] Image healthImage;
    [SerializeField] HealthController adventurerHealth;
    [SerializeField] GameObject keyPrefab;
    [SerializeField] GameObject keyIcon;
    
    [SerializeField] GameObject doorMid;  
    [SerializeField] GameObject doorTop; 
    [SerializeField] Sprite doorClosedMid; 
    [SerializeField] Sprite doorClosedTop; 
    [SerializeField] Sprite doorOpenMid; 
    [SerializeField] Sprite doorOpenTop;

    private int coins = 0;  
    private bool hasKey = false;  

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeCollectables();
        UpdateDoorState();
    }
    
    void InitializeCollectables()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        if (coins.Length > 0)
        {
            int randomIndex = Random.Range(0, coins.Length);
            GameObject randomCoin = coins[randomIndex];
            GameObject keyObject = Instantiate(keyPrefab, randomCoin.transform.position, Quaternion.identity);
            keyObject.SetActive(true);
            Destroy(randomCoin);
        }
        else
        {
            Debug.LogWarning("No coins found to replace with a key.");
        }
    }
    
    void UpdateDoorState()
    {
        if (hasKey)
        {
            SoundManager.Instance.PlayDoorUnlockSound();
            doorMid.GetComponent<SpriteRenderer>().sprite = doorOpenMid;
            doorTop.GetComponent<SpriteRenderer>().sprite = doorOpenTop;
        }
        else
        {
            doorMid.GetComponent<SpriteRenderer>().sprite = doorClosedMid;
            doorTop.GetComponent<SpriteRenderer>().sprite = doorClosedTop;
        }
    }
    
    public void AddHealth(int health)
    {
        float h = (float)health / adventurerHealth.vitality;
        healthImage.fillAmount = h;
    }

    public void AddCoins(int amount)
    {
        SoundManager.Instance.PlayCoinCollectSound();
        coins += amount;
        coinText.text = coins.ToString();
    }

    public void AddKey()
    {
        hasKey = true;
        keyIcon.SetActive(true);
        UpdateDoorState(); 
    }

    public bool HasKey()
    {
        return hasKey;
    }

    private void OnEnable()
    {
        adventurerHealth.HealthEvent += AddHealth;
    }

    private void OnDisable()
    {
        adventurerHealth.HealthEvent -= AddHealth;
    }
}
