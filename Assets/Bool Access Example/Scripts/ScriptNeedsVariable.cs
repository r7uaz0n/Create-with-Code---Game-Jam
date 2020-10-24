using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNeedsVariable : MonoBehaviour
{
   //Here's the script variable! Scripts can be used as variables
   //just like floats or bools, and when you declare them, you have
   //access to all of their public values! It's common practice to 
   //name these variables the same name of their script, but with
   //a lowercase first letter!
    public ScriptWithVariable scriptWithVariable;
    

    void Update()
    {
        //This debug is accessing the variable declared above. Once you call the variable
        //type . and you'll get a list of all the things accessable to you. Because boolToGet
        //is public, you can access it here!
        Debug.Log("The boolean value on the cube is " + scriptWithVariable.boolToGet); 
    }
}
