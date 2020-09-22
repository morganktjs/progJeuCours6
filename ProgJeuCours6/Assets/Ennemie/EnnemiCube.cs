using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiCube : Ennemi
{
    private GameObject player;
    private Rigidbody myRigidBody;
    public AudioMusic audioMusic;
    public GameObject deathParticle;
    void Update()
    {
        myRigidBody.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, 20 * Time.deltaTime));
    }
    public override void EnnemieStart()
    {
        myRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Die()
    {
        soundPlayer.PlayMusic(audioMusic);
        Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
