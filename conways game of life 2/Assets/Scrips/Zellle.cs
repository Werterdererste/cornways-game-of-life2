using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zellle : MonoBehaviour
{
    bool isLife = false;
    private SpriteRenderer spriteRenderer;
    bool nextgenerationLife = false;

    public int x;
    public int y;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        setColor();
    }

    public bool GetLife()
    {
        return isLife;
    }
    public void SetNextLife(bool nextLife)
    {
        nextgenerationLife = nextLife;
    }
    public void SetLife()
    {
        isLife = nextgenerationLife;
        setColor();
    }
    void setColor()
    {
        if (isLife)
        {
            spriteRenderer.color = Color.white;
        }
        else
            spriteRenderer.color = Color.black;
    }

    void OnMouseDown()
    {
        SwitchLife();
    }    
    
    void SwitchLife()
    {
        isLife = !isLife;
        setColor();
    }
}
