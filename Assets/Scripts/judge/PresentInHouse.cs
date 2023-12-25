using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentInHouse : MonoBehaviour
{
    public bool inHouse = false;

    private void Start()
    {
        inHouse = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inHouse = true;
    }
}
