﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    public float maxHealth = 50f;
    public float currentHealth;

    private float forHowLong;
    private float byHowMuch;

    public ChasePlayer chase_player;
    public ShootPlayer shoot_player;
    public BossScript boss;

    public Image healthImage; // **wont do until ask nikhil


	// Use this for initialization
	void Start () {
        //maxHealth = 50f; // set  high for testing
        //Debug.Log("Start of an enemy");
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Death();
		
	}


    public virtual void HurtEnemy(float damage)
    {

        DamageTextHandler.makeDamageText(damage.ToString(), transform,1f,"Enemy");
        if (chase_player != null)
        {
            chase_player.hurt = true;
        }
        else if(shoot_player != null)
        {
            //Debug.Log("hey i got hurt");
            shoot_player.hurt = true;
        }
        else if(boss != null)
        {
            boss.hurt = true;
        }
        //Debug.Log("Ouch I was hit");
        currentHealth -= damage;
        healthImage.fillAmount = currentHealth / maxHealth;  // **wont do until ask nikhil
    }
    public void StunEnemy(float stunTime)
    {
        if(chase_player != null)
        {
            chase_player.stunned = true;
            chase_player.stunTime = stunTime;
        }
        else
        {
            shoot_player.stunned = true;
            shoot_player.stunTime = stunTime;
        }
    }

    public void SlowEnemy(float HowMuch, float HowLong)
    {
        forHowLong = HowLong;
        byHowMuch = HowMuch;
        if(shoot_player)
        {
            shoot_player.speed = shoot_player.speed / byHowMuch;
        }
        else
        {
            chase_player.speed = chase_player.speed / byHowMuch;
        }
        StartCoroutine(SlowDown());
    }

    private IEnumerator  SlowDown()
    {
        yield return new WaitForSeconds(forHowLong);
        if (shoot_player)
        {
            shoot_player.speed = shoot_player.speed * byHowMuch;    //The co-routine waits for a bit, then restores things to normal
        }
        else
        {
            chase_player.speed = chase_player.speed * byHowMuch;
        }
    }
    public void Death()
    {
        if(currentHealth <= 0)
        {
            if (shoot_player || chase_player)
            {
                //Debug.Log("Dead");
                Destroy(this.gameObject);
            }
        }
    }
}
