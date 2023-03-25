using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform playerPos;


    private void Start()
    {

        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerPos.transform.position = spawnPoint.transform.position;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }   


}
