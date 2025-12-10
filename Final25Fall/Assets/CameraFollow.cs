using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Player
    public float smooth = 0.2f;
    public Vector3 offset = new Vector3(0, 1.5f, 0); // 摄像机向上偏移 1.5，可调

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.z = -10;  // 确保相机保持在前方

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smooth);
    }
}
