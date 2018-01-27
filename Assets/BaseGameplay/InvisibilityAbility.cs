﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class InvisibilityAbility : CooldownAbility
{

    public float invisLength = 1.0f;

    protected RigidbodyController controller;
    protected Player player;

    protected bool isVisible = true;
    protected float invisibilityTimer = 0.0f;

    protected void Start()
    {
        controller = GetComponent<RigidbodyController>();
        player = controller.player;
    }

    // Update is called once per frame
    void Update () {
        CooldownUpdate();

        //turn visible if timer ran out
        if (!isVisible)
        {
            invisibilityTimer += Time.deltaTime;
            if(invisibilityTimer > invisLength)
            {
                invisibilityTimer = 0.0f;
                isVisible = true;
                var componentsToDisable = GetComponentsInChildren<Renderer>();
                foreach (Renderer c in componentsToDisable)
                {
                    c.enabled = true;
                }
            }
        }

        //turn invisible if button is pressed
        if (player.Device.Action2.WasPressed && TryToUseAbility())
        {
            Debug.Log("Invisibility used by " + player.Color);
            var componentsToDisable = GetComponentsInChildren<Renderer>();
            foreach (Renderer c in componentsToDisable)
            {
                c.enabled = false;
            }
            isVisible = false;
        }
    }
}
