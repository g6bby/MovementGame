using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = thePlayer.GetComponent<PlayerMovement>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("TeleportChar");

        }
    }

    IEnumerator TeleportChar()
    {
        //playerMovement.enabled = false;

        yield return new WaitForSeconds(.01f);

        thePlayer.transform.position = teleportTarget.transform.position;

        //Destroy(GetComponent<Teleport>());

        //yield return new WaitForSeconds(.01f);

        //playerMovement.enabled = true;

    }
}
