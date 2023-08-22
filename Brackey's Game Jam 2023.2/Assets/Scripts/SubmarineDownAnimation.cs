using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineDownAnimation : MonoBehaviour
{

    [SerializeField] GameObject submarine;
    void Start()
    {
        submarine.GetComponent<Animator>().Play("SubmarineDownAnimation");
    }    
}
