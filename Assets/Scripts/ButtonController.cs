using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button kakuninButton;

    public Shooter shooter;
    void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }
    void Start()
    {
        kakuninButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!shooter.setObject && shooter.canClick && shooter.count != 0)
        {
            kakuninButton.gameObject.SetActive(true);
        }
        else
        {
            kakuninButton.gameObject.SetActive(false);
        }
    }
}
