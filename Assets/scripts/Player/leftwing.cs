﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftwing : MonoBehaviour
{
    PolygonCollider2D wingCollider;
    public GameObject particleSystem;
    public float repairTime = 20f;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        wingCollider = this.GetComponent<PolygonCollider2D>();
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "missile" || other.gameObject.tag == "enemy"){
            GameObject parent = transform.parent.gameObject;
            parent.GetComponent<Player>().leftWingDamage = true;
            toggleCollider();
            StartCoroutine(repairWing());

        }
    }

    public void toggleCollider(){
        wingCollider.enabled = !wingCollider.enabled;
        particleSystem.SetActive(!particleSystem.activeSelf);
    }

    IEnumerator repairWing(){
        yield return new WaitForSecondsRealtime(repairTime);
        GameObject parent = transform.parent.gameObject;
        parent.GetComponent<Player>().leftWingDamage = false;
        toggleCollider();

    }
}