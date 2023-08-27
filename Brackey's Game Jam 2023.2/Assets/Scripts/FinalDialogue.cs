using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FinalDialogue : MonoBehaviour
{    

    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public TextMeshProUGUI textForTime;

    public string[] lines;
    private int index;

    private float numOfSecs;

    [SerializeField] private float textSpeed;

    [SerializeField] private SceneManagerScript sceneManagerScript;

    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject resetButton;

    void Start()
    {
        textForTime.enabled = false;
        numOfSecs = PlayerPrefs.GetFloat("Timer");
        textForTime.text = "Total Time " + TimeSpan.FromSeconds(numOfSecs).Hours + "h " + TimeSpan.FromSeconds(numOfSecs).Minutes + "m " + TimeSpan.FromSeconds(numOfSecs).Seconds + "s.";
        text.text = string.Empty;
        StartDialogue();
        StartCoroutine(ShowButtons());
    }
    void Update()
    {
    }
    IEnumerator ShowButtons()
    {
        yield return new WaitForSeconds(15);
        textForTime.enabled = true;
        yield return new WaitForSeconds(5);
        resetButton.SetActive(true);
        menuButton.SetActive(true);
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