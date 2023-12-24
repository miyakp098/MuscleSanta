using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountNum : MonoBehaviour
{
    private Shooter shooter;
    public TextMeshPro presentNumText;
    void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        presentNumText.text = $"残り{shooter.count}個";
    }
}
