using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_Chiseling : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody pickaxeRb;
    private float swingSpeed = 5;

    void Start()
    {
        pickaxeRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Vector3.right * swingSpeed * Time.deltaTime);
        }

    }

    function OnTriggerEnter(other : Collider)
    {
        if (other.gameObject.tag == "Quarry Block")
                    Destroy(other.gameObject);  
          
    }
}
