using UnityEngine;

public class MegafactoryVue : MonoBehaviour {
  [SerializeField] private BuildingsVue _buildingsVue;
  [SerializeField] private UnitsVue _unitsVue;

  public void SetManagers(ResourceLoader resourceLoader) {
    _buildingsVue.SetManagers(resourceLoader);
    _unitsVue.SetManagers(resourceLoader);
  }

  public void DrawBuilding(Building building) {
    _buildingsVue.DrawBuilding(building);
  }

  public void DrawUnit(Unit unit, HexCoordinates coordinates) {
    _unitsVue.DrawUnit(unit, coordinates);
  }
}
