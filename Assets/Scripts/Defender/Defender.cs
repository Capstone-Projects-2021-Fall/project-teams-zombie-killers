using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	//public GameObject projectilePrefab;
	[SerializeField] int starCost = 20;

	[SerializeField] private float startingHealth;
	protected float currentHealth;

	

	void Awake()
	{
		//StartCoroutine(repeatedShootProjectile());
		currentHealth = startingHealth;
	}

    //TODO Needs to be tested
    public void takeDamage(float damage)
	{
		currentHealth -= damage;
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

 //   #region Shoot Functions
 //   IEnumerator repeatedShootProjectile()
	//{
	//	while (this)
	//	{
	//		yield return new WaitForSeconds(shootSpeed);
	//		shootProjectile();
	//	}
	//}

	//protected void shootProjectile()
	//{
	//	Instantiate(projectilePrefab, transform);
	//}
	//#endregion

	#region Resource/Star Functions

	public int GetStarCost()
	{
		return starCost;
	}

	public void addStars(int amount)
	{
		FindObjectOfType<StarDisplay>().AddStars(amount);
	}
    #endregion
}
