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
    [SerializeField] GameObject button1_1;
    [SerializeField] GameObject button1_2;
    [SerializeField] GameObject button2_1;
    [SerializeField] GameObject button2_2;
    [SerializeField] GameObject button3_1;
    [SerializeField] GameObject button3_2;
    [SerializeField] GameObject button3_3;
    [SerializeField] GameObject button3_4;
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
                WaitForDialogue2(button1_1, button1_2, skipButton);
            }
            else if (index == 8)
            {
                WaitForDialogue2(button2_1, button2_2, skipButton);
            }
            else if (index == 11)
            {
                WaitForDialogue4(button3_1, button3_2, button3_3, button3_4, skipButton);
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
    
    void Answered4(GameObject button1, GameObject button2, GameObject button3, GameObject button4, GameObject skipButton)
    {
        skipButton.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }

    void Answered2(GameObject button1, GameObject button2, GameObject skipButton)
    {
        skipButton.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);
    }

    public void TrueAnswer()
    {
        if (index == 7)
        {
            Answered2(button1_1, button1_2, skipButton);
        }
        else if(index == 9)
        {
            Answered2(button2_1, button2_2, skipButton);
        }
        else if (index == 12)
        {
            Answered4(button3_1, button3_2, button3_3, button3_4, skipButton);

        }
        lines[index+1] = "The answer was.....  CORRECT!";
        SkipDialogue();
        
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(4);
        submarineHealth.SubmarineHealth--;

    }
    IEnumerator WaitForDialogue2(GameObject button1, GameObject button2,GameObject skipButton)
    {
        skipButton.SetActive(false);
        yield return new WaitForSeconds(3);
        button1.SetActive(true);
        button2.SetActive(true);

    }
    IEnumerator WaitForDialogue4(GameObject button1, GameObject button2, GameObject button3, GameObject button4, GameObject skipButton)
    {
        skipButton.SetActive(false);
        yield return new WaitForSeconds(3);
        button1.SetActive(true);
        button2.SetActive(true);
        button2.SetActive(true);
        button2.SetActive(true);
    }

    public void FalseAnswer()
    {
        if (index == 7)
        {
            Answered2(button1_1, button1_2, skipButton);
        }
        else if (index == 9)
        {
            Answered2(button2_1, button2_2, skipButton);
        }
        else if (index == 12)
        {
            Answered4(button3_1, button3_2, button3_3, button3_4, skipButton);
        }
        if (submarineHealth.SubmarineHealth-1 == 0)
        {
            lines[index + 1] = "The answer was.....  NOT CORRECT... You have no HP left so we have to restart. I'm sorry...";
            SkipDialogue();
            skipButton.SetActive(false);
            StartCoroutine(Die());
        }
        else
        {
            submarineHealth.SubmarineHealth--;
            lines[index + 1] = "The answer was.....  NOT CORRECT...";
            SkipDialogue();
        }
      
        
    }
}