﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public PlayerClass playerScript;
    public Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = playerScript.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            playerScript.gameObject.transform.position = spawnPoint;
            playerScript.rb.velocity = Vector3.zero;
        }
    }
}
