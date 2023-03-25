using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLevel2 : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform playerPos;

    public GameObject thePlayer;

    PlayerMovement playerMovement;


    private void Start()
    {

        spawnPoint = GameObject.FindGameObjectWithTag("Respawn2").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        playerMovement = thePlayer.GetComponent<PlayerMovement>();


    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy2")
        {
            StartCoroutine("Respawn2");

        }
    }

    

    IEnumerator Respawn2()
    {


        yield return new WaitForSeconds(.01f);

        playerPos.transform.position = spawnPoint.transform.position;


    }

}
