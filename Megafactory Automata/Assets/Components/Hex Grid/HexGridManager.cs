using System.Collections.Generic;

public class HexGridManager {
  private HexGridVue _vue;

  private List<HexTile> _tileList;
  private Dictionary<HexCoordinates, HexTile> _tileDict;
  public HexTile Origin { get; private set; }
  public HexTile[] TileList { get { return _tileList.ToArray(); } }

  public bool HasTileAt(HexCoordinates coordinates) { return _tileDict.ContainsKey(coordinates); }
  public HexTile GetTileAt(HexCoordinates coordinates) { return _tileDict[coordinates]; }

  public HexGridManager(HexGridVue vue) {
    _vue = vue;

    _tileList = new List<HexTile>();
    _tileDict = new Dictionary<HexCoordinates, HexTile>();
  }

  public void Initialize() {
    HexTile origin = CreateTile(HexCoordinates.origin);
    Origin = origin;
    // We draw after creating buildings so we can call AddVision first (and not have to call draw twice)
  }

  public HexTile[] GetNeighbours(HexTile tile) {
    List<HexCoordinates> neighbourCoords = HexCoordinates.GetNeighbourCoordinates(tile.Coordinates);
    List<HexTile> neighbours = new List<HexTile>(6);

    for (int i = 0; i < neighbourCoords.Count; ++i)
      if (HasTileAt(neighbourCoords[i]))
        neighbours.Add(_tileDict[neighbourCoords[i]]);

    return neighbours.ToArray();
  }

  private HexTile CreateTile(HexCoordinates coordinates) {
    if (!_tileDict.ContainsKey(coordinates)) {
      HexTile tile = new HexTile(coordinates);
      AddTile(tile);
      return tile;
    }

    return _tileDict[coordinates];
  }

  private void AddTile(HexTile tile) {
    _tileList.Add(tile);

    if (_tileDict.ContainsKey(tile.Coordinates))
      UnityEngine.Debug.LogError("Overriding existing tile at " + tile.Coordinates.ToPrettyString());
    _tileDict.Add(tile.Coordinates, tile);
  }

  public void AddVision(Building building) {
    if (building.Vision > 0) {
      List<HexCoordinates> neighboursInRange = HexCoordinates.GetCoordinatesAround(building.Coordinates, building.Vision);
      for (int i = 0; i < neighboursInRange.Count; ++i)
        CreateTile(neighboursInRange[i]);
    }

    _vue.Draw(_tileList.ToArray());
  }
}
