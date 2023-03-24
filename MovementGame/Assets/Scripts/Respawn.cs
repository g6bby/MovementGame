using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform playerPos;
    //private GameObject[] fishObj;

   public PlayerInventory playerInventory;

    private void Start()
    {

        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //fishObj = GameObject.FindGameObjectsWithTag("Fish");

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerPos.transform.position = spawnPoint.transform.position;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }   

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == ("Enemy"))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}

}
