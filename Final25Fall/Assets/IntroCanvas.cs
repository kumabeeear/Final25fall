using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroController : MonoBehaviour
{
    public Sprite[] introImages;       // 四张图片
    public Image introImageUI;         // 显示用的 UI Image
    public TextMeshProUGUI hintText;   // 提示文本

    private int index = 0;
    private bool introFinished = false;

    void Start()
    {
        // 显示第一张图片
        introImageUI.sprite = introImages[index];
        Time.timeScale = 0f; // 暂停游戏（可选，看你需求）
    }

    void Update()
    {
        if (introFinished) return;

        if (Input.anyKeyDown)
        {
            index++;

            if (index >= introImages.Length)
            {
                FinishIntro();
                return;
            }

            introImageUI.sprite = introImages[index];
        }
    }

    void FinishIntro()
    {
        introFinished = true;
        Time.timeScale = 1f; // 恢复游戏逻辑（如果你暂停了）
        gameObject.SetActive(false); // 关闭 IntroCanvas
    }
}
