using NUnit.Framework.Internal.Filters;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    public int FoodAmount;
    private Vector2 _direction = Vector2.right;

    private MaskPickup parentScript;
    private void Start()
    {
        parentScript = transform.parent.transform.GetComponentInParent<MaskPickup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {  _direction = Vector2.up; }
        else if (Input.GetKeyDown(KeyCode.S) ) 
        {_direction = Vector2.down;}
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        { _direction = Vector2.right; }

        if (FoodAmount >= 5)
        {
            parentScript.CollectMask();
            MaskPickup.MinigamingIt = false;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3( Mathf.Round( this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y)+ _direction.y, Mathf.Round(this.transform.position.z));
    }
}



