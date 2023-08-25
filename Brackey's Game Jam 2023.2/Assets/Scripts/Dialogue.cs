using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;
    public string[] lines;
    private int index;
    [SerializeField] Health submarineHealth;
    [SerializeField] private float textSpeed;
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject buttonOne1;
    [SerializeField] GameObject buttonOne2;
    [SerializeField] GameObject buttonTwo1;
    [SerializeField] GameObject buttonTwo2;

    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
        Debug.Log(index);
    }

    public void SkipDialogue()
    {
        if(text.text == lines[index])
        {
            if (index == 6)
            {
                buttonOne1.SetActive(true);
                buttonOne2.SetActive(true);
                skipButton.SetActive(false);
            }
            else if (index == 8)
            {
                buttonTwo1.SetActive(true);
                buttonTwo2.SetActive(true);
                skipButton.SetActive(false);
            }
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
        foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void TrueAnswer()
    {
        if (index == 7)
        {
            buttonOne1.SetActive(false);
            buttonOne2.SetActive(false);
            skipButton.SetActive(true);
        }
        else if(index == 9)
        {
            buttonTwo1.SetActive(false);
            buttonTwo2.SetActive(false);
            skipButton.SetActive(true);

        }
        lines[index+1] = "The answer was.....  CORRECT!";
        SkipDialogue();
        
    }
    public void FalseAnswer()
    {
        if (index == 7)
        {
            buttonOne1.SetActive(false);
            buttonOne2.SetActive(false);
            skipButton.SetActive(true);

        }
        else if (index == 9)
        {
            buttonTwo1.SetActive(false);
            buttonTwo2.SetActive(false);
            skipButton.SetActive(true);
        }
        lines[index + 1] = "The answer was.....  NOT CORRECT...";
        submarineHealth.SubmarineHealth--;
        SkipDialogue();
        
    }
}