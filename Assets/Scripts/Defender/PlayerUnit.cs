using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
	public GameObject projectilePrefab;

	[SerializeField] private float baseStartingHealth;
	protected float startingHealth
	{
		get { return baseStartingHealth; }
		set { baseStartingHealth = value; }
	}
	protected float currentHealth;

	[SerializeField] private int baseAttack;
	protected int attack
	{
		get { return baseAttack; }
		set { baseAttack = value; }
	}

	[SerializeField] private int baseRange;
	protected int range
	{
		get { return baseRange; }
		set { baseRange = value; }
	}

	[SerializeField] private float baseAttackRefresh;
	protected float attackRefresh
	{
		get { return baseAttackRefresh; }
		set { baseAttackRefresh = value; }
	}

	private float _lastAttack = 0.0f;


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
	}

	IEnumerator repeatedShootProjectile()
    {
		while (this)
		{
			yield return new WaitForSeconds(attackRefresh);
			shootProjectile();
		}
	}

	void shootProjectile()
	{
		Instantiate(projectilePrefab, transform);
	}
}
