using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearLog : MonoBehaviour
{
    public string targetSceneName = "Clear"; // 遷移先のシーン名
    public string targetTag = "Finish"; // 衝突判定を行う対象のタグ名

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトのタグが指定されたタグと一致するかをチェックする
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ターゲットシーン名が設定されている場合、シーン遷移を行う
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                // 現在のシーン名を保存する
                if (SceneTracker.Instance != null)
                {
                    SceneTracker.Instance.SetPreviousScene(SceneManager.GetActiveScene().name);
                }

                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
