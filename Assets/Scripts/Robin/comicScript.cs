using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class comicScript : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [SerializeField] private RawImage[] Panels;

    [SerializeField] private float disappearSpeed = 1f;
    [SerializeField] private float waitTime = 2f;

    private int currentPanel = 0;

    private bool isFading = true;
    private float waitTimer = 0f;
    private bool finished = false;

    [SerializeField] AudioSource pageAudio;
    [SerializeField] AudioSource yayAudio;

    private bool yayPlayed;

    private void Start()
    {
        foreach (RawImage panel in Panels)
        {
            Color c = panel.color;
            c.a = 1f;
            panel.color = c;
        }
    }

    private void Update()
    {
        if (finished)
        {
            ComicDone();
            return;
        }

        if (currentPanel >= Panels.Length)
        {
            finished = true;
            return;
        }

        RawImage panel = Panels[currentPanel];
        Color c = panel.color;

        if (isFading)
        {
            c.a -= disappearSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);

            panel.color = c;

            if (c.a <= 0f)
            {
                isFading = false;
                waitTimer = 0f;
            }
        }

        else
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                currentPanel++;
                isFading = true;
                pageAudio.Play();
            }
        }
    }

    private void ComicDone()
    {
        if (!yayPlayed)
        {
            yayPlayed = true;
            yayAudio.Play();
        }
        canvas.gameObject.SetActive(true);
    }
}
