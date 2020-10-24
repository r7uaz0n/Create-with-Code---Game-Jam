using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaunchPickAxe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickaxePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pickaxePrefab, transform.position, pickaxePrefab.transform.rotation);
        }   
    }
}
