﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

    public GameObject enemyBullet;

    void Start()
    {
        enemyBullet = GameObject.FindGameObjectWithTag("Enemy");
    }
	private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 0.5f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            enemyBullet.GetComponent<EnemyStats>().enemyShotGunDamage();
            Debug.Log("hit");
            Invoke("hideBullet", 0.05f);

        }
       

       //GameObject.FindGameObjectWithTag("Enemy").
    }
}
