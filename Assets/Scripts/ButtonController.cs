using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button kakuninButton;

    public Shooter Shooter;

    void Start()
    {
        kakuninButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Shooter.setObject && Shooter.canClick)
        {
            kakuninButton.gameObject.SetActive(true);
        }
        else
        {
            kakuninButton.gameObject.SetActive(false);
        }
    }
}
