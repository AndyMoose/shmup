using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

    public static Pooler current;
    public GameObject obj;
    public int pooledAmt = 15;
    public bool canGrow = true;
    List<GameObject> pooledObj;

    private void Awake()
    {
        current = this;
    }

    void Start() {
        pooledObj = new List<GameObject>();

        //Adds a number of game object equal to pooledAmt to object pool and sets them as inactive
        for (int c = 0; c < pooledAmt; c++)
        {
            GameObject objIn = (GameObject)Instantiate(obj);
            objIn.SetActive(false);
            pooledObj.Add(objIn);
        }
    }
    
    //Returns a pooled object if one is available, if not expands the list to allow more shots.  If canGrow is false, it returns nothing.
    public GameObject GetPooledObject()
    {
        for(int c = 0; c < pooledObj.Count; c++)
        {
            if(!pooledObj[c].activeInHierarchy)
            {
                return pooledObj[c];
            }
        }

        if(canGrow)
        {
            GameObject objIn = (GameObject)Instantiate(obj);
            pooledObj.Add(objIn);
            return objIn;
        }

        return null;
    }
   
}
	
	

