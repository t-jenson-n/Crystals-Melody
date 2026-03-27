using System.Collections;
using UnityEngine;

public class Runes : MonoBehaviour
{
    public Sprite[] frames;
    public float delay = 1f;

    private SpriteRenderer sr;
    private Coroutine animCoroutine;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if (animCoroutine != null)
        {
            StopCoroutine(animCoroutine);
        }

        animCoroutine = StartCoroutine(AnimateOnce());
    }

    IEnumerator AnimateOnce()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            sr.sprite = frames[i];
            yield return new WaitForSeconds(delay);
        }
    }
}