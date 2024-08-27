using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // キャラクターの移動速度

    void Update()
    {
        // 矢印キーの左右の入力を検出し、キャラクターを左右に移動させる
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
