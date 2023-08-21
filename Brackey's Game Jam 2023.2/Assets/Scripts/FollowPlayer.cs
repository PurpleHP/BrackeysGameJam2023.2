using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject submarine;
    private Vector3 newPosition;
    // Update is called once per frame
    private void Start()
    {
        Vector3 newPosition = transform.position;
        
    }
    void Update()
    {
        newPosition.x = submarine.transform.position.x;
        transform.position = newPosition;
    }
}
