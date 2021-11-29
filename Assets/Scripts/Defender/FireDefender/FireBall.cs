using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public GameObject onFirePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.GetComponentsInChildren<OnFire>().Length == 0)
            {
                GameObject fireEffect = Instantiate(onFirePrefab, collision.transform.position, Quaternion.identity);
                fireEffect.transform.parent = collision.transform;
            }
            
        }
        
    }
}
