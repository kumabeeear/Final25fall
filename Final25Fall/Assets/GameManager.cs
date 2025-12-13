using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedCount = 0;
    public int totalCount = 10;

    public TextMeshProUGUI progressText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCollectible()
    {
        collectedCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        progressText.text = $"{collectedCount}/{totalCount}";
    }

    public bool IsComplete()
    {
        return collectedCount >= totalCount;
    }
}
