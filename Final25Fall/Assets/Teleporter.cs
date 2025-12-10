using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;    // 传送目标位置
    public KeyCode teleportKey = KeyCode.F;

    private bool playerInRange = false;

    void Update()
    {
        // 玩家在触发区内 且 按下F
        if (playerInRange && Input.GetKeyDown(teleportKey))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportTarget.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;
    }
}
