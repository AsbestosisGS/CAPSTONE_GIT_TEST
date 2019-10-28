﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSack : MonoBehaviour
{
    public GameObject spiderlingPrefab;
    private GameObject[] spiderlings = new GameObject[6];
    private GameObject prePoolHolder;
    private int spiderlingsToSpawn;
    private Vector3 yIncrease = new Vector3(0, 2, 0);
    private int SpiderlingsToSpawn()
    {
        return spiderlingsToSpawn = Random.Range(3, 6);
    }

    private void Awake()
    {        
        for(int i = 0; i < spiderlings.Length; i++)
        {
            prePoolHolder = Instantiate(spiderlingPrefab/*, this.transform*/);
            prePoolHolder.transform.position = transform.position + yIncrease;
            
            prePoolHolder.SetActive(false);
            spiderlings[i] = prePoolHolder;
        }
    }

    private void OnEnable()
    {

        for (int i = 0; i < spiderlings.Length; i++)
        {
            spiderlings[i].transform.position = transform.position + yIncrease;

            spiderlings[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            SpiderlingsToSpawn();
            StartCoroutine(ReleaseTheHounds(other.transform));
            Debug.Log("Pop");
        }
    }

    private IEnumerator ReleaseTheHounds(Transform player)
    {
        for (int i = 0; i < spiderlingsToSpawn; i++)
        {
            spiderlings[i].GetComponent<Spiderlings>().SetPlayer(player);
            spiderlings[i].SetActive(true);
            yield return new WaitForSecondsRealtime(0.8f);
        }

        gameObject.SetActive(false);
    }

}
