using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GenerateText : MonoBehaviour
{
    public static GenerateText generateText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float letterDelay = 0.05f; // adjust this value
    public string sentence;
    public float upTimer;
    private Queue<string> queue;

    private void Awake()
    {
        generateText = this;
    }

    private void Update()
    {
        upTimer -= Time.deltaTime;
        if (upTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void StartLetters()
    {
        queue = new Queue<string>();
        queue.Enqueue(sentence);

        StartCoroutine(Letters());
    }

    IEnumerator Letters()
    {
        dialogText.text = "";

        if (queue.Count != 0)
        {
            string sentence = queue.Dequeue();

            foreach (char letter in sentence)
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
        }
    }
}