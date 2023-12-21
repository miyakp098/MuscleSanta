using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    private Animator animator;
    public GameObject setObj;
    private Vector2 setPosi;

    void Start()
    {
        animator = GetComponent<Animator>();
        setPosi = setObj.transform.position;
    }


    void Update()
    {
        
    }

    private void StandingPosi()
    {
        setObj.transform.position = setPosi;
    }

    private void StandingPosi2()
    {
        setObj.transform.position = new Vector2(setPosi.x + 1, setPosi.y + 1);
    }
}
