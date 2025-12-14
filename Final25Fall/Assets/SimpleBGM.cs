using UnityEngine;

public class SimpleBGM : MonoBehaviour
{
    public AudioClip bgm;

    private static SimpleBGM instance;

    void Awake()
    {
        // 保证全局只有一个
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.loop = true;
        source.Play();
    }
}
