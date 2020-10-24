using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaunchPickAxe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickaxePrefab;
    public Vector3 offset; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pickaxePrefab, transform.position + offset, pickaxePrefab.transform.rotation);
        }   
    }
}
