using UnityEngine;

public class UnitsVue : MonoBehaviour {
  private ResourceLoader _resourceLoader;

  public void SetManagers(ResourceLoader resourceLoader) {
    _resourceLoader = resourceLoader;
  }

  public void DrawUnit(Unit unit, HexCoordinates coordinates) {
    GameObject prefab = _resourceLoader.LoadOnce("Units/" + unit.Name);
    GameObject instance = Instantiate(prefab);
    instance.transform.position = coordinates.WorldPosition;

    instance.transform.SetParent(transform, false);
  }
}
