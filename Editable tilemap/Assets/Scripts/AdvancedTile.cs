using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[Serializable]
[CreateAssetMenu(fileName = "New Advanced Tile", menuName = "Tiles/Advanced Tile")]
public class AdvancedTile : TileBase
{
    public int id;
    public Sprite[] spriteSet;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int x = -1 ; x <= 1 ; x++)
        {
            for (int y = -1 ; y<=1 ; y++)
            {
                Vector3Int newPosition = position + new Vector3Int(x, y, 0);
                if (tilemap.GetTile(newPosition) != null)
                {
                    tilemap.RefreshTile(newPosition);
                }
            }
        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        bool[] neighbours = { false, false, false, false, false, false, false, false };
        int[] index_and_rotation = { 0, 0 };

        if (tilemap.GetTile(position + new Vector3Int(-1, 1, 0)) != null)
            neighbours[0] = true;
        if (tilemap.GetTile(position + new Vector3Int(0, 1, 0)) != null)
            neighbours[1] = true;
        if (tilemap.GetTile(position + new Vector3Int(1, 1, 0)) != null)
            neighbours[2] = true;
        if (tilemap.GetTile(position + new Vector3Int(1, 0, 0)) != null)
            neighbours[3] = true;
        if (tilemap.GetTile(position + new Vector3Int(1, -1, 0)) != null)
            neighbours[4] = true;
        if (tilemap.GetTile(position + new Vector3Int(0, -1, 0)) != null)
            neighbours[5] = true;
        if (tilemap.GetTile(position + new Vector3Int(-1, -1, 0)) != null)
            neighbours[6] = true;
        if (tilemap.GetTile(position + new Vector3Int(-1, 0, 0)) != null)
            neighbours[7] = true;

        index_and_rotation = TilesBehaviour.What_tile(neighbours);

        tileData.flags = TileFlags.LockAll;
        tileData.colliderType = Tile.ColliderType.Sprite;
        tileData.color = Color.white;
        tileData.sprite = spriteSet[index_and_rotation[0]];
        tileData.transform = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, (index_and_rotation[1] * 90)), Vector3.one);
    }
}
