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

        for (int i = 0; i < frames.Length; i++)
        {
            spriteRenderer.sprite = frames[i].sprite;

            if (frames[i].sound != null && audioSource != null)
            {
                audioSource.PlayOneShot(frames[i].sound);
            }

            yield return new WaitForSeconds(delay);
        }

        if (reRune != null)
            reRune.gameObject.SetActive(true);

        if (instructions_text != null)
            instructions_text.gameObject.SetActive(true);
    }

    public void ReplayAnimation()
    {
        GameObject[] crystals = GetComponent<MusicController>().crystals;

        for (int i = 0; i < crystals.Length; i++)
        {
            crystals[i].GetComponent<dragdrop>().ResetPos();
        }

        StartCoroutine(PlayAnimation());
    }
}

