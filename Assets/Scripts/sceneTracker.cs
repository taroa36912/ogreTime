using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance { get; private set; }
    public string previousScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        // シーンが読み込まれるたびに呼ばれる
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // イベントを解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーン名が "Scene" で始まる場合のみ previousScene に記録
        if (Instance != null && scene.name.StartsWith("Scene"))
        {
            Instance.SetPreviousScene(scene.name);
        }
    }

    public void SetPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }
}
