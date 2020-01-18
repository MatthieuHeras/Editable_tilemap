using UnityEngine;
using UnityEngine.Tilemaps;

public class AdvancedTilemap : MonoBehaviour
{

    private Tilemap tilemap;
    
    public AdvancedTile[] tileList;
    public Camera mainCamera;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // To modify, Update must NOT exist
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SetTile(tilemap.WorldToCell(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), 0, true);
        // Equivalent
            //Vector3Int mousePosition = tilemap.WorldToCell(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
            //SetTile(mousePosition, true);
        if (Input.GetMouseButtonDown(2))
            SetTile(tilemap.WorldToCell(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), 0, false);
        // Equivalent
            //Vector3Int mousePosition = tilemap.WorldToCell(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
            //SetTile(mousePosition, false);
    }

// SetTile + AddTile + RefreshTile

    public void SetTile(Vector3Int position, int tileID, bool add)
    {
        tilemap.SetTile(position, null);
        if (!add)
            return;
        tilemap.SetTile(position, tileList[tileID]);
    }

    public void Generation()
    {
    
    }
}
