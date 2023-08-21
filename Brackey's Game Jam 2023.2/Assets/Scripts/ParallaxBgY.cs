using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBgY : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
