using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDefender : MonoBehaviour
{
    public GameObject ninjaStarPrefab;
    private GameObject instanciatedNinjaStarPrefab;

    void Start()
    {
        instanciatedNinjaStarPrefab = Instantiate(ninjaStarPrefab, transform);
    }

    private void OnDestroy()
    {
        Destroy(instanciatedNinjaStarPrefab);
    }
}
