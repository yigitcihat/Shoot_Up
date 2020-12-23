using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcaController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag != "ball")&&(other.gameObject.tag != "zemin"))
        {
            Destroy(other.gameObject);
        }
    }
}
