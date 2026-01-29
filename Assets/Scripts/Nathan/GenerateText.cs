using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GenerateText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float letterDelay = 0.05f; // adjust this value
    public string[] sentences;
    private Queue<string> queue;

    private void Start()
    {
        queue = new Queue<string>();

        foreach (string sentence in sentences)
        {
            queue.Enqueue(sentence);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Letters());
        }
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