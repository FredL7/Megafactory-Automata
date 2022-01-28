using System.Collections.Generic;

public class BuildingsManager {
  private Headquarters _headquarters;
  public Headquarters Headquarters { get { return _headquarters; } }

  private List<Building> _buildings;
  public Building[] Buildings { get { return _buildings.ToArray(); } }

  public BuildingsManager() {
    _buildings = new List<Building>();
  }

  public void Initialize(HexTile origin) {
    _headquarters = new Headquarters(ComplexBuildingDB.Instance.GetHeadquartersData());
    origin.SetHeadquarters(_headquarters);
    AddBuilding(_headquarters);
  }

  public void AddComplexBuilding(ComplexBuilding building, HexTile tile) {
    tile.SetComplexBuilding(building);
    AddBuilding(building);
  }

  public void AddSimpleBuilding(SimpleBuilding building, HexTile tile) {
    tile.SetBuilding(building);
    AddBuilding(building);
  }

  private void AddBuilding(Building building) {
    _buildings.Add(building);
  }

  public Yield GetYieldPerTurn() {
    Yield yield = new Yield();

    for (int i = 0; i < _buildings.Count; ++i)
      yield += _buildings[i].GetYield();

    return yield;
  }
}
