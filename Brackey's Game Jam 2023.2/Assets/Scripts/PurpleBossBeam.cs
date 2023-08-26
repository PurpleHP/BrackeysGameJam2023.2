using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBossBeam : MonoBehaviour
{
    [SerializeField] GameObject purpleBoss;

    [SerializeField] GameObject laser;

    private float timer = 10f;
    public float rotationSpeed = 36f; // Degrees per second
    public float rotationDuration = 10f; // Seconds
    public bool laserIsRotating = true;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(RotateForSeconds(rotationDuration));
            timer = 20f;
        }

    }
    IEnumerator RotateForSeconds(float seconds)
    {
        laserIsRotating = true;
        var proj = Instantiate(laser, purpleBoss.transform.position, Quaternion.identity);
        float elapsedTime = 0f;
        while (elapsedTime < seconds)
        {
            proj.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(proj);
        laserIsRotating = false;
    }
}
