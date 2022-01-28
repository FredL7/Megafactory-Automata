public class TileFilterHasNotBuilding : ITileFilter {
  public bool Valid(HexTile tile, HexGridManager grid) {
    return !tile.HasBuilding;
  }
}
