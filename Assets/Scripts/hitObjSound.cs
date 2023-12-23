using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObjSound : MonoBehaviour
{
    //SE
    public AudioClip hitSE;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.PlaySE(hitSE);
    }
}
