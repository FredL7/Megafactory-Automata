public class TileFilterAdjacentToBuilding : ITileFilter {
  public bool Valid(HexTile tile, HexGridManager grid) {
    bool adjacent = false;

    HexTile[] neighbours = grid.GetNeighbours(tile);
    for (int i = 0; i < neighbours.Length; ++i)
      if (neighbours[i].HasBuilding)
        adjacent = true;

    return adjacent;
  }
}
