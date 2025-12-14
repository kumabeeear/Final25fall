using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. 加收集数
            GameManager.Instance.AddCollectible();

            // 2. 播放音效
            PlaySound();

            // 3. 播放特效
            PlayEffect();

            // 4. 销毁物品
            Destroy(gameObject);
        }
    }

    void PlaySound()
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position,
                1f
            );
        }
    }

    void PlayEffect()
    {
        if (collectEffectPrefab != null)
        {
            GameObject effect = Instantiate(
                collectEffectPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, 0.5f); // 特效 0.5 秒后自动销毁
        }
    }
}
