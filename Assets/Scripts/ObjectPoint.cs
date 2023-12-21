using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    private Animator animator;
    public GameObject setObj;
    private Vector2 setPosi;

    public GameObject targetObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        setPosi = setObj.transform.position;
        SetSortingOrder(targetObject, 10); // Order in Layer初期値
    }



    private void StandingPosi()
    {
        setObj.transform.position = setPosi;
        SetSortingOrder(targetObject, 10); // Order in Layer初期値
    }

    private void StandingPosi2()
    {
        setObj.transform.position = new Vector2(setPosi.x　-0.1f, setPosi.y -0.1f);
    }

    private void ThrowingPosi1()
    {
        setObj.transform.position = new Vector2(setPosi.x - 2.8f, setPosi.y + 0.21f);
        SetSortingOrder(targetObject, -10); // Order in Layerを後ろに
    }
    private void ThrowingPosi2()
    {
        setObj.transform.position = new Vector2(setPosi.x - 2.6f, setPosi.y + 0.64f);
    }
    private void ThrowingPosi3()
    {
        setObj.transform.position = new Vector2(setPosi.x - 2.6f, setPosi.y + 0.64f);

    }

    void SetSortingOrder(GameObject obj, int order)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = order;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on the object.");
        }
    }
}
