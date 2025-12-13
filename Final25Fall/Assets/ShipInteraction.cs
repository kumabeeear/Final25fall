using UnityEngine;
using TMPro;

public class ShipInteraction : MonoBehaviour
{
    public TextMeshProUGUI centerHintText;
    public GameObject endingImage;
    public KeyCode leaveKey = KeyCode.F;

    private bool playerInRange = false;

    void Update()
    {
        if (!playerInRange) return;

        if (GameManager.Instance.IsComplete())
        {
            centerHintText.text = "Press F to leave";
            
            if (Input.GetKeyDown(leaveKey))
            {
                Leave();
            }
        }
        else
        {
            centerHintText.text =
                "You can't abandon them.\nFind everyone before leaving.";
        }
    }

    void Leave()
    {
        centerHintText.gameObject.SetActive(false);
        endingImage.SetActive(true);
        Time.timeScale = 0f; // 游戏暂停（可选）
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            centerHintText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            centerHintText.gameObject.SetActive(false);
        }
    }
}
