using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RuneMelody : MonoBehaviour
{
    [System.Serializable]
    public struct FrameData
    {
        public Sprite sprite;
        public AudioClip sound;
    }
    public FrameData[] frames;

    public GameObject runes;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public Button reRune;
    public TextMeshProUGUI instructions_text;

    public float delay;

    public float songDelay;

    void Start()
    {
        spriteRenderer = runes.GetComponent<SpriteRenderer>();
        audioSource = runes.GetComponent<AudioSource>();
        StartCoroutine(PlayAnimation());
    }

    public IEnumerator PlayAnimation()
    {
        if (reRune != null)
            reRune.gameObject.SetActive(false);

        if (instructions_text != null)
            instructions_text.gameObject.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.sprite = frames[i].sprite;

            if (frames[i].sound != null && audioSource != null)
            {
                audioSource.PlayOneShot(frames[i].sound);
            }

            yield return new WaitForSeconds(delay);
        }

        spriteRenderer.sprite = frames[0].sprite;

        if (reRune != null)
            reRune.gameObject.SetActive(true);

        if (instructions_text != null)
            instructions_text.gameObject.SetActive(true);

    }

    public void ReplayAnimation()
    {
        foreach (GameObject gameObject in GetComponent<MusicController>().rocks)
        {
            gameObject.GetComponent<dragdrop>().ResetPos();
        }

        StartCoroutine(PlayAnimation());
    }

    public IEnumerator CorrectAnimation()
    {
        yield return new WaitForSeconds(2);

        spriteRenderer.sprite = frames[5].sprite;


        if (frames[5].sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(frames[5].sound);

            yield return new WaitForSeconds(songDelay);
        }
    }
}

