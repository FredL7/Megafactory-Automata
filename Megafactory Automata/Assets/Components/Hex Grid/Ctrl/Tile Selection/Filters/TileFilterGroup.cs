public class TileFilterGroup : ITileFilter {
  ITileFilter[] _filters;

  public TileFilterGroup(ITileFilter[] filters) {
    _filters = filters;
  }

  public bool Valid(HexTile tile, HexGridManager grid) {
    bool valid = true;

    for (int i = 0; i < _filters.Length; ++i) {
      if (!_filters[i].Valid(tile, grid))
        valid = false;
    }

    return valid;
  }

}
