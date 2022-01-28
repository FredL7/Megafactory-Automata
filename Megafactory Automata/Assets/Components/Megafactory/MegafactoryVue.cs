using UnityEngine;

public class MegafactoryVue : MonoBehaviour {
  [SerializeField] private BuildingsVue _buildingsVue;

  public void SetManagers(ResourceLoader resourceLoader) {
    _buildingsVue.SetManagers(resourceLoader);
  }

  public void DrawBuilding(Building building) {
    _buildingsVue.DrawBuilding(building);
  }
}
