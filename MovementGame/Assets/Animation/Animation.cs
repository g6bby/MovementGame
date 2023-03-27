using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator penguinAnim;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        penguinAnim = gameObject.GetComponent<Animator>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            penguinAnim.SetBool("isJumping", true);
        }
        else
        {
            penguinAnim.SetBool("isJumping", false);
        }
 
    }
}