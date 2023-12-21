using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    private Animator animator;
    public GameObject setObj;
    private Vector2 setPosi;
    public ClickMoveObject2D clickMoveScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        setPosi = setObj.transform.position;
    }



    private void StandingPosi()
    {
        setObj.transform.position = setPosi;
    }

    private void StandingPosi2()
    {
        setObj.transform.position = new Vector2(setPosi.x　-0.1f, setPosi.y -0.1f);
    }

    private void ThrowingPosi1()
    {
        setObj.transform.position = new Vector2(setPosi.x - 2.8f, setPosi.y + 0.21f);
    }
    private void ThrowingPosi2()
    {
        setObj.transform.position = new Vector2(setPosi.x - 2.6f, setPosi.y + 0.64f);
    }
    private void ThrowingPosi3()
    {
        if (setObj == null)
        {
            Debug.LogError("setObj is null.");
            return;
        }

        if (clickMoveScript == null)
        {
            Debug.LogError("clickMoveScript is null.");
            return;
        }

        if (setPosi == null)
        {
            Debug.LogError("setPosi is null.");
            return;
        }
        setObj.transform.position = new Vector2(setPosi.x - 2.6f, setPosi.y + 0.64f);
        clickMoveScript.DeleteSelectedObject();
    }
}
