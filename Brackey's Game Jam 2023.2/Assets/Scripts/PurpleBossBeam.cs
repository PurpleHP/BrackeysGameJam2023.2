using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBossBeam : MonoBehaviour
{
    [SerializeField] GameObject purpleBoss;

    [SerializeField] GameObject laser;

    [SerializeField] PurpleBoss boss;

    [SerializeField] PurpleBossRoom purpleRoom;

    private float timer = 10f;
    public float rotationSpeed = 36f; // Degrees per second
    public float rotationDuration = 10f; // Seconds
    public bool laserIsRotating = true;

    void Update()
    {
        if (purpleRoom.isOnPurpleBoss)
        {
            if (boss.purpleBossHealth > 0)
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
            else
            {
                laser.GetComponent<SpriteRenderer>().enabled = false;
                laser.GetComponent<BoxCollider2D>().enabled = false;

            }
        }

        
    }
    IEnumerator RotateForSeconds(float seconds)
    {
        if(boss.purpleBossHealth > 0)
        {
            laserIsRotating = true;
            var proj = Instantiate(laser, purpleBoss.transform.position, Quaternion.identity);
            float elapsedTime = 0f;
            while ((elapsedTime < seconds) && (boss.purpleBossHealth > 0))
            {

                proj.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            Destroy(proj);
            laserIsRotating = false;

        }
       
    }
}
