using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	public GameObject projectilePrefab;
	[SerializeField] int starCost = 100;

	public void addStars(int amount)
    {
		FindObjectOfType<StarDisplay>().AddStars(amount);
    }

	public int GetStarCost()
    {
		return starCost;
    }

	[SerializeField] private float baseStartingHealth;
	protected float startingHealth
	{
		get { return baseStartingHealth; }
		set { baseStartingHealth = value; }
	}
	protected float currentHealth;
	[SerializeField] private float shootSpeed;

	void Awake()
	{
		StartCoroutine(repeatedShootProjectile());
	}

	//TODO Needs to be tested
	public void takeDamage(float damage)
	{
		this.currentHealth = currentHealth - damage;
		if (this.currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnDestroy()
	{
		//send messager to manager
		DefenderSpawner.singleton.Unoccupy(new Vector2(transform.position.x, transform.position.y));
	}

	IEnumerator repeatedShootProjectile()
	{
		while (this)
		{
			yield return new WaitForSeconds(shootSpeed);
			shootProjectile();
		}
	}

	void shootProjectile()
	{
		Instantiate(projectilePrefab, transform);
	}
}
