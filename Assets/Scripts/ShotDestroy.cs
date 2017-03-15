using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDestroy : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Boundary")
            gameObject.SetActive(false);
    }

}