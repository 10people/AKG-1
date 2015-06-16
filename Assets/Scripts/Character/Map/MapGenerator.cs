﻿using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<string> TileList;

    public List<Sprite> TileUnitSpriteList;

    private List<GameObject> tileGOList = new List<GameObject>();
    private GameObject lastSpriteGO;
    private Sprite lastSprite;

    [ContextMenu("Execute")]
    public void Generate()
    {
        foreach (var tileName in TileList)
        {
            var sprite = TileUnitSpriteList.Find(tile => tile.name.Equals(tileName));
            if (sprite != null)
            {
                var go = new GameObject {name = tileName};
                var render = go.AddComponent<SpriteRenderer>();
                render.sprite = sprite;

                if (lastSpriteGO == null)
                {
                    go.transform.position = transform.position;
                }
                else
                {
                    go.transform.position = lastSpriteGO.transform.position + new Vector3(lastSprite.bounds.size.x, 0);
                }
                lastSpriteGO = go;
                lastSprite = sprite;
                go.transform.parent = transform;

                tileGOList.Add(go);
            }
            else
            {
                Debug.LogWarning("Tile with name: " + tileName + " does not exist from TileUnitSpriteList, please double check it out.");
            }
        }
    }

    [ContextMenu("Cleanup")]
    public void Cleanup()
    {
        tileGOList.ForEach(DestroyImmediate);
        tileGOList.Clear();
    }

    void Awake()
    {
        
    }
}
