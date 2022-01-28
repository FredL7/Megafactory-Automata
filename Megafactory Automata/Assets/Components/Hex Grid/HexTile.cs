using UnityEngine;

public class HexTile {
  private HexGridManager _manager;

  private ColorDelta _color;
  public ColorDelta Color { get { return _color; } }

  public HexCoordinates Coordinates { get; private set; }
  public Vector3 Position { get { return Coordinates.WorldPosition; } }

  #region Buildings
  public bool HasBuilding { get; private set; }
  public bool HasComplexBuilding { get; private set; }
  public bool HasHeadquarters { get; private set; }

  private Building _building;
  private ComplexBuilding _complexBuilding;
  private Headquarters _headquarters;

  public void SetBuilding(Building building) {
    HasBuilding = true;
    _building = building;
    building.Tile = this;
  }

  public void SetComplexBuilding(ComplexBuilding complexBuilding) {
    HasBuilding = HasComplexBuilding = true;
    _building = _complexBuilding = complexBuilding;
    complexBuilding.Tile = this;
  }

  public void SetHeadquarters(Headquarters headquarters) {
    HasBuilding = HasComplexBuilding = HasHeadquarters = true;
    _building = _complexBuilding = _headquarters = headquarters;
    headquarters.Tile = this;
  }
  #endregion Buildings

  public HexTile(HexCoordinates coordinates) {
    Coordinates = coordinates;

    _color = new ColorDelta();
  }
}
