using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cursor sprite manager defines cursor image according Object Tag
/// Attention! Be sure you apply equal amount of Sprites and Tag names in Inspector
/// </summary>
public class CursorManager : MonoBehaviour
{
    public LayerMask clickableLayer; // layermask used to isolate raycasts against clickable layers

    public Texture2D defaultCursorSprite;
    public List<Texture2D> cursorSprites;
    public List<string> objectTags;

    private Dictionary<string, Texture2D> cursorSpriteDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //Dictionary Initialization
        cursorSpriteDictionary = new Dictionary<string, Texture2D>(); 
        if(objectTags.Count == cursorSprites.Count)
        {
            for (int i = 0; i < objectTags.Count; i++)
            {
                Debug.Log(objectTags[i]);
                cursorSpriteDictionary.Add(objectTags[i].ToString(), cursorSprites[i]);
            }
        } else
        {
            Debug.LogError("Sprite Count no equal to object Tags Count! /n Check CursorManager settings in Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast into scene
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50))
        {
            if (hit.collider.gameObject.tag != "Untagged")
            {
                string objectTag = hit.collider.gameObject.tag;
                Cursor.SetCursor(cursorSpriteDictionary[objectTag], Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursorSprite, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(defaultCursorSprite, Vector2.zero, CursorMode.Auto);
        }
    }
}
