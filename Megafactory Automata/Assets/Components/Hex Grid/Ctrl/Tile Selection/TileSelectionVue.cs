using System.Collections.Generic;
using UnityEngine;

public class TileSelectionVue : MonoBehaviour {
  [SerializeField] private HexMesh hexMesh;
  [SerializeField] private HexMeshTileSelectCtrl hover;

  public void Draw(HexTile[] tiles, HexGridManager grid, ITileFilter filter) {
    List<HexTile> validTiles = new List<HexTile>(tiles.Length);

    for (int i = 0; i < tiles.Length; ++i)
      if (filter.Valid(tiles[i], grid))
        validTiles.Add(tiles[i]);

    if (validTiles.Count == 0)
      Debug.LogError("No valid tiles found");

    hexMesh.Draw(validTiles.ToArray());

    hover.Open();
  }

  public void Erase() {
    hexMesh.Erase();
    hover.Close();
  }
}
