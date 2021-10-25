using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] private float shootSpeed;

    void Awake()
    {
        StartCoroutine(shootProjectile());
    }
    
    IEnumerator shootProjectile()
    {
        while(this)
        {
            yield return new WaitForSeconds(shootSpeed);
            Instantiate(projectilePrefab, transform);
        }
    }
}