using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneButton : MonoBehaviour
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
        
        // 次のシーン名を決定
        string nextScene = GetNextSceneName(previousScene);

        // 次のシーンが設定されている場合、シーン遷移を実行
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private string GetNextSceneName(string previousScene)
    {
        switch (previousScene)
        {
            case "Scene1":
                return "Scene2";
            case "Scene2":
                return "Scene3";
            case "Scene3":
                return "AllClear";
	    case "Scene4":
                return "Scene5";
	    case "Scene5":
                return "Scene6";
	    case "Scene6":
                return "Scene7";
	    case "Scene7":
                return "Scene8";
	    case "Scene8":
                return "Scene9";
	    case "Scene9":
                return "Scene10";
	    case "Scene10":
                return "start";
            default:
                return "start";
        }
    }
}
