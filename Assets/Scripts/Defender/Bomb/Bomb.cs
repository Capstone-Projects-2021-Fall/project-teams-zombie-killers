using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer changeColor;

    // Start is called before the first frame update
    void Start()
    {
        changeColor = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = changeColor.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(BlowUp());
        }
    }

    IEnumerator BlowUp()
    {
        Debug.Log("Begin Blowing Up");
        for(int i = 0; i < 3; i++) {
            changeColor.material = matWhite;
            Invoke("ResetMaterial", .05f);
            yield return new WaitForSeconds(0.25f);
        }
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ResetMaterial()
    {
        changeColor.material = matDefault;
    }
}
