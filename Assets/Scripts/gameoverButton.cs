using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSceneButton : MonoBehaviour
{
    private void Start()
    {
        // ボタンのコンポーネントを取得
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // ボタンが押されたときのリスナーを追加
            button.onClick.AddListener(OnButtonPress);
        }
    }

    private void OnButtonPress()
    {
        // 遷移元のシーン名を取得
        string previousScene = SceneTracker.Instance != null ? SceneTracker.Instance.previousScene : null;
        
        // 遷移元のシーンに戻る
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
    }
}
