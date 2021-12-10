/*
 * Author: Joaquín León Martínez
 * Date: 10/12/2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class in charge of randomize the car prefab (The only difference is the color)
 */
public class CarSpawner : MonoBehaviour
{
    #region Attributes

    //List of models car prefabs
    [SerializeField]
    private GameObject[] carPrefabs;

    #endregion

    #region Methods
    void Start()
    {
        if (carPrefabs.Length > 0)
        {
            Instantiate(GetRandomCarPref(), transform);
        }
        else
        {
            Debug.Log("There are no available cars");
        }
    }

    public GameObject GetRandomCarPref()
    {
        return carPrefabs[Random.Range(0, carPrefabs.Length)];
    }

    #endregion
}
