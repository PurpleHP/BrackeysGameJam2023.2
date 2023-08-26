using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{

	[SerializeField]
	int numberOfProjectiles;

	private int[] numOfProjList = { 45, 60, 72 };
	private int index = 0;
	[SerializeField] GameObject purpleBoss;
	[SerializeField]
	GameObject projectile;

	Vector2 startPoint;

	[SerializeField] float radius, moveSpeed;
	[SerializeField] float cooldown = 4f;
	private float currentCooldown;

	void Start()
	{
		currentCooldown = cooldown;
		radius = 10f;
		moveSpeed = 20;
	}

	public void Fire()
	{
		startPoint = purpleBoss.transform.position;
		SpawnProjectiles(numOfProjList[index]);
		if(index+1 == numOfProjList.Length)
        {
			index = 0;
        }
        else
        {
			index++;
        }
	}

	private void Update()
    {
		if (cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}
		if(cooldown <= 0)
        {
			cooldown = currentCooldown;
			Fire();
		}
	}

    void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{

			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D>().velocity =
				new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
			Destroy(proj, cooldown-0.2f);
		}
	}

}