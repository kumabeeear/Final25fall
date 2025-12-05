using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;

    private int jumpCount = 0; // 跳跃次数
    private int maxJump = 2;   // 最大跳跃次数（2 段跳）

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 水平移动
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // 跳跃
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // 重置竖直速度，防止二段跳变弱
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jumpCount++;  // 使用一次跳跃次数
        }
    }

    // 判断落地，重置跳跃次数
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
