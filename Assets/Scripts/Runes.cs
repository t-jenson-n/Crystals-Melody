using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class FrameData
{
    public Sprite sprite;
    public AudioClip sound;
}

public class Runes : MonoBehaviour
{
    public Button reRune;
    public TextMeshProUGUI title_text;

    public FrameData[] frames;
    public float delay = 0.1f;

    private SpriteRenderer sr;
    private AudioSource audioSource;
    private Coroutine animCoroutine;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    public IEnumerator PlayAnimation()
    {
        if (reRune != null)
            reRune.gameObject.SetActive(false);

        if (title_text != null)
            title_text.gameObject.SetActive(false);

        for (int i = 0; i < frames.Length; i++)
        {
            sr.sprite = frames[i].sprite;

            if (frames[i].sound != null && audioSource != null)
            {
                audioSource.PlayOneShot(frames[i].sound);
            }

            yield return new WaitForSeconds(delay);
        }

        if (reRune != null)
            reRune.gameObject.SetActive(true);

        if (title_text != null)
            title_text.gameObject.SetActive(true);
    }

    IEnumerator AnimateOnce()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            sr.sprite = frames[i].sprite;

            if (frames[i].sound != null)
            {
                audioSource.PlayOneShot(frames[i].sound);
            }

            yield return new WaitForSeconds(delay);
        }
    }

    public void PlayAnimationButton()
    {
        StartCoroutine(PlayAnimation());
    }
}