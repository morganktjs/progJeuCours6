using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemi : MonoBehaviour, Damageable
{
    int lifeTotal = 1;
    protected SoundPlayer soundPlayer;

    public abstract void EnnemieStart();
    public abstract void Die();
    void Start()
    {
        soundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        EnnemieStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;
        if (lifeTotal <= 0)
        {
            Die();
        }
    }

}
