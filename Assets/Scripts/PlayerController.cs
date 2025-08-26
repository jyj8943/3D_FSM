using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputs playerInputs { get; private set; }
    public PlayerInputs.PlayerActions playerActions { get; private set; }

    private void Start()
    {
        playerInputs = new PlayerInputs();
        playerActions = playerInputs.Player;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
