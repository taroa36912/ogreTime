using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicPlayer : MonoBehaviour
{
    public string targetSceneName = "Clear";  // ここでターゲットシーン名を設定
    public AudioClip targetSceneMusic;        // ターゲットシーンで再生する音楽
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            PlayTargetSceneMusic();
        }
    }

    void PlayTargetSceneMusic()
    {
        if (targetSceneMusic != null && audioSource != null)
        {
            audioSource.clip = targetSceneMusic;
            audioSource.Play();
        }
    }
}
