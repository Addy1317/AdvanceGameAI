using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    //gene for colour
    public float r;
    public float g;
    public float b;

    public float timeToDie = 0f;

    private bool dead = false;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer.color = new Color(r, b, g);
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elasped;
        Debug.Log("Dead At:" +  timeToDie);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }
}

