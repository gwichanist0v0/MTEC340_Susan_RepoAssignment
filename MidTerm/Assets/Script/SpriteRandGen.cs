using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteRandGen : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Sprite sprite;
    [SerializeField] int MaxValue;
    [SerializeField] Grid grid;
    [SerializeField] GameObject SpritePrefab;

    [SerializeField] int whileLoopMax;


    private BoundsInt bounds;
    [SerializeField] MonkTest monk;

    // Start is called before the first frame update
    void Start()
    {
        bounds = tilemap.cellBounds;

        for (int i = 0; i < MaxValue; i++)
        {
            DrawRandomTiles();
        }

        whileLoopMax = 10;

        Debug.Log(bounds); 

    }

    void DrawRandomTiles()
    {

        

        int whileCount = 0;
       

        while (whileCount < whileLoopMax)
        {
            int RandX = Random.Range(bounds.min.x, (bounds.max.x + 1));
            int RandY = Random.Range(bounds.min.y, (bounds.max.y + 1));
            //Debug.Log(RandY + "VALIHUSYTLIKfgAuHEWjrG" + RandX); 
            //Debug.Log(bounds.max.x + "alkdjufhal" + tilemap.cellBounds.max.y);
            //Debug.Log(RandX + " " + RandY);

            Vector3Int randGrid = monk.TileGridSync(new Vector3Int(RandX, RandY, 0));

            int val = grid.GetValue(randGrid.x, randGrid.y);

            
            //Debug.Log(randGrid.x + "aslkdjufh" + randGrid.y);

            if (val == 0)
            {
                Vector3Int randomCell = new Vector3Int(RandX, RandY, bounds.min.z);
                //Debug.Log("randomCell : " + randomCell);
                // Generate a random position within the bounds of the Tilemap
                // Create a new Tile with the desired sprite
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = sprite;

                // Place the tile at the chosen cell
                tilemap.SetTile(randomCell, tile);
                monk.ReceiveRND(randomCell);

                int adjacentCount = Random.Range(2, 6); // Randomly choose 4 or 5 adjacent tiles
                for (int j = 0; j < adjacentCount; j++)
                {
                    Vector3Int adjacentCell = randomCell + GetRandomAdjacentOffset();
                    tilemap.SetTile(adjacentCell, tile);
                    monk.ReceiveADJ(adjacentCell);
                }
                break; 
           }

            // Draw additional tiles adjacent to the chosen cell
            whileCount++;
        }

        //for (int i = 0; i < MaxValue; i++)
        //{ 
   

        //    if (val == 0)
        //    {

        //        Vector3Int randomCell = new Vector3Int(RandX, RandY, bounds.min.z);


        //        // Generate a random position within the bounds of the Tilemap
        //        // Create a new Tile with the desired sprite
        //        Tile tile = ScriptableObject.CreateInstance<Tile>();
        //        tile.sprite = sprite;

        //        // Place the tile at the chosen cell
        //        tilemap.SetTile(randomCell, tile);
        //        monk.ReceiveRND(randomCell);

        //        // Draw additional tiles adjacent to the chosen cell
        //        int adjacentCount = Random.Range(2, 6); // Randomly choose 4 or 5 adjacent tiles
        //        for (int j = 0; j < adjacentCount; j++)
        //        {
        //            Vector3Int adjacentCell = randomCell + GetRandomAdjacentOffset();
        //            tilemap.SetTile(adjacentCell, tile);
        //            monk.ReceiveADJ(adjacentCell);


        //        }
        //    }
        //}

    }

    void FindTile()
    {
        
        Vector3Int randomCell = new Vector3Int(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), bounds.min.z);


    }

    Vector3Int GetRandomAdjacentOffset()
    {
        Vector2Int[] offsets = {
            new Vector2Int(1, 0),  // Right
            new Vector2Int(-1, 0), // Left
            new Vector2Int(0, 1),  // Up
            new Vector2Int(0, -1)  // Down
        };

        int randomIndex = Random.Range(0, offsets.Length);
        return new Vector3Int(offsets[randomIndex].x, offsets[randomIndex].y, 0);
    }
}
