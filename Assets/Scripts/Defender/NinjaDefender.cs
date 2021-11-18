using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDefender : Defender
{
    public GameObject ninjaStarPrefab;
    private GameObject instanciatedNinjaStarPrefab;


    // Start is called before the first frame update
    void Start()
    {
        instanciatedNinjaStarPrefab = Instantiate(ninjaStarPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(instanciatedNinjaStarPrefab);
    }
}
