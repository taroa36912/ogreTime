using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class CustomScript : MonoBehaviour
{
    public float interval;
    public float duration;
    public string overlappingTag = "obstacle";
    public string gameoverSceneName = "Gameover";
    public TextMeshProUGUI intervalText; 

    private AudioSource audioSource; 
    private SpriteRenderer oniSpriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        intervalText = GameObject.Find("IntervalText").GetComponent<TextMeshProUGUI>();

        GameObject oniNewObject = GameObject.Find("oni");
        if (oniNewObject != null)
        {
            oniSpriteRenderer = oniNewObject.GetComponent<SpriteRenderer>();
        }

        StartCoroutine(TransitionRoutine());
    }

    IEnumerator TransitionRoutine()
    {
        while (true)
        {
            interval = Random.Range(2.1f, 5.0f);
            duration = Random.Range(2.1f, 5.0f);

            if (oniSpriteRenderer != null)
            {
                oniSpriteRenderer.flipX = true;
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            float remainingIntervalTime = interval;
            while (remainingIntervalTime > 0)
            {
                // 残り2秒を切ったら表示を開始
                if (remainingIntervalTime <= 2.0f)
                {
                    intervalText.text = "鬼時間まで: " + remainingIntervalTime.ToString("F2") + "s";
                }
                else
                {
                    intervalText.text = ""; // 表示をクリア
                }

                remainingIntervalTime -= Time.deltaTime;
                yield return null;
            }

            intervalText.text = ""; // カウントダウン終了後、表示をクリア

            audioSource.Stop();

            if (oniSpriteRenderer != null)
            {
                oniSpriteRenderer.flipX = false;
            }

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                if (elapsedTime % 0.5f < Time.deltaTime)
                {
                    if (!IsOverlappingWithTag(overlappingTag))
                    {
                        SceneManager.LoadScene(gameoverSceneName);
                    }
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }

    bool IsOverlappingWithTag(string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
