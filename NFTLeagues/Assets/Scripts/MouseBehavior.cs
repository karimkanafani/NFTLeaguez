using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    public Texture2D cursor;

    public void OnMouseOver()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    
}
