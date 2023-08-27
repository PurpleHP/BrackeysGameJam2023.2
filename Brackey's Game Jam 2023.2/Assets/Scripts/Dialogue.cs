using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    [SerializeField] SaveCoin coinScript;

    [SerializeField] GameObject panel;

    [SerializeField] DepthCalculator depth;
    [SerializeField] public TextMeshProUGUI depthTextTrue;
    [SerializeField] public TextMeshProUGUI depthTextFalse1;
    [SerializeField] public TextMeshProUGUI depthTextFalse2;
    [SerializeField] public TextMeshProUGUI depthTextFalse3;

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
    [SerializeField] GameObject button4_1;
    [SerializeField] GameObject button4_2;
    [SerializeField] GameObject button4_3;
    [SerializeField] GameObject button4_4;
    [SerializeField] GameObject button5_1;
    [SerializeField] GameObject button5_2;
    [SerializeField] GameObject button5_3;
    [SerializeField] GameObject button5_4;
    [SerializeField] GameObject button6_1;
    [SerializeField] GameObject button6_2;
    [SerializeField] GameObject button6_3;
    [SerializeField] GameObject button6_4;
    [SerializeField] GameObject button7_1;
    [SerializeField] GameObject button7_2;
    [SerializeField] GameObject button7_3;
    [SerializeField] GameObject button7_4;
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }
    public void SkipDialogue()
    {
        if(text.text == lines[index])
        {
            if (index == 6)
            {
                StartCoroutine(Answered2(button1_1, button1_2, skipButton));
            }
            else if (index == 8)
            {
                StartCoroutine(Answered2(button2_1, button2_2, skipButton));
            }
            else if (index == 11)
            {
                StartCoroutine(Answered4(button3_1, button3_2, button3_3, button3_4, skipButton));
            }
            else if(index== 14)
            {
                StartCoroutine(Answered4(button4_1, button4_2, button4_3, button4_4, skipButton));

            }
            else if (index == 17)
            {
                StartCoroutine(Answered4(button5_1, button5_2, button5_3, button5_4, skipButton));

            }
            else if (index == 20)
            {
                depthTextTrue.text = depth._intDepth.ToString();
                depthTextFalse1.text = (depth._intDepth + 391).ToString();
                depthTextFalse2.text = (depth._intDepth - 448).ToString();
                depthTextFalse3.text = (depth._intDepth + 563).ToString();
                StartCoroutine(Answered4(button6_1, button6_2, button6_3, button6_4, skipButton));

            }
            else if (index == 22)
            {
                StartCoroutine(Answered4(button7_1, button7_2, button7_3, button7_4, skipButton));
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
            panel.SetActive(false);
        }
    }
    
    void WaitForDialogue4(GameObject button1, GameObject button2, GameObject button3, GameObject button4, GameObject skipButton) //Seçim yaptýktan sonra
    {
        skipButton.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
    }

    void WaitForDialogue2(GameObject button1, GameObject button2, GameObject skipButton)
    {
        skipButton.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(4);
        submarineHealth.SubmarineHealth = 0;

    }
    IEnumerator Answered2(GameObject button1, GameObject button2, GameObject skipButton) //Seçim için (butonlarýn çýkmasý için cooldown)
    {
        skipButton.SetActive(false);
        yield return new WaitForSeconds(3);
        button1.SetActive(true);
        button2.SetActive(true);

    }
    IEnumerator Answered4(GameObject button1, GameObject button2, GameObject button3, GameObject button4, GameObject skipButton)
    {
        skipButton.SetActive(false);
        if(index == 17 || index == 16 || index == 18)
        {
            yield return new WaitForSeconds(4.5f);
        }
        else
        {
            yield return new WaitForSeconds(3);

        }
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }

    public void TrueAnswer()
    {
        if (index == 7)
        {
            WaitForDialogue2(button1_1, button1_2, skipButton);

        }
        else if(index == 9)
        {
            WaitForDialogue2(button2_1, button2_2, skipButton);
        }
        else if (index == 12)
        {
            WaitForDialogue4(button3_1, button3_2, button3_3, button3_4, skipButton);

        }
        else if (index == 15)
        {
            WaitForDialogue4(button4_1, button4_2, button4_3, button4_4, skipButton);

        }
        else if (index == 18)
        {
            WaitForDialogue4(button5_1, button5_2, button5_3, button5_4, skipButton);

        }
        else if (index == 21)
        {
            WaitForDialogue4(button6_1, button6_2, button6_3, button6_4, skipButton);

        }
        else if (index == 23)
        {
            WaitForDialogue4(button7_1, button7_2, button7_3, button7_4, skipButton);
        }

        if(index == 23 && coinScript.oxygenLevel >= 3)
        {
            lines[index + 1] = "The answer was.....  CORRECT! And you also seem to have enough oxygen level to DIVE DEEPER!";
        }
        else if (index == 23 && coinScript.oxygenLevel < 3){
            lines[index + 1] = "The answer was.....  CORRECT! But you don't have enough oxygen level (3) to DIVE DEEPER :( Come back when you are ready";
            SkipDialogue();
            skipButton.SetActive(false);
            StartCoroutine(Die());
        }
        else
        {
            lines[index + 1] = "The answer was.....  CORRECT!";
            SkipDialogue();
        }
        
        
    }
   

    public void FalseAnswer()
    {
        if (index == 7)
        {
            WaitForDialogue2(button1_1, button1_2, skipButton);
        }
        else if (index == 9)
        {
            WaitForDialogue2(button2_1, button2_2, skipButton);
        }
        else if (index == 12)
        {
            WaitForDialogue4(button3_1, button3_2, button3_3, button3_4, skipButton);
        }
        else if (index == 15)
        {
            WaitForDialogue4(button4_1, button4_2, button4_3, button4_4, skipButton);

        }
        else if (index == 18)
        {
            WaitForDialogue4(button5_1, button5_2, button5_3, button5_4, skipButton);

        }
        else if (index == 21)
        {
            WaitForDialogue4(button6_1, button6_2, button6_3, button6_4, skipButton);

        }
        else if (index == 23)
        {
            WaitForDialogue4(button7_1, button7_2, button7_3, button7_4, skipButton);
        }
        if (index == 23  && coinScript.oxygenLevel >= 3)
        {
            lines[index + 1] = "The answer was.....  NOT CORRECT... But don't worry you have enough oxygen level (the correct answers were both 3 and 4) so you can continue :)";

        }
        else if(index == 23 && coinScript.oxygenLevel < 3)
        {
            lines[index + 1] = "The answer was.....  NOT CORRECT... Also you don't have enough oxygen level (3) to DIVE DEEPER :( Come back when you are ready";
            SkipDialogue();
            skipButton.SetActive(false);
            StartCoroutine(Die());
        }
        else if (submarineHealth.SubmarineHealth-1 == 0)
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