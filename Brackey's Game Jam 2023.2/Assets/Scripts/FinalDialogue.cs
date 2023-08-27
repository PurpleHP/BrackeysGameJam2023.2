using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FinalDialogue : MonoBehaviour
{    

    [SerializeField] public TextMeshProUGUI text;
    public string[] lines;
    private int index;

    [SerializeField] private float textSpeed;

    [SerializeField] GameObject menuButton;

    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
    }

    public void SkipDialogue()
    {
        if (text.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            text.text = lines[index];
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //panel.SetActive(false);
        }
    }
}