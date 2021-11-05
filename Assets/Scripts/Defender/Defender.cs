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

	// Start is called before the first frame update 
	void Start()
	{

	}


	// Update is called once per frame
	void Update()
	{

	}


	//TODO Needs to be tested
	public void takeDamage(float damage)
	{
		this.currentHealth = currentHealth - damage;
		if (this.currentHealth <= 0)
		{
			this.destroy();
		}
	}


	//TODO Needs to be tested
	public void destroy()
	{
		Destroy(gameObject);

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
