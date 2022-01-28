using UnityEngine;

public class BuildingsVue : MonoBehaviour {
  private ResourceLoader _resourceLoader;

  public void SetManagers(ResourceLoader resourceLoader) {
    _resourceLoader = resourceLoader;
  }

  public void DrawBuilding(Building building) {
    GameObject prefab = _resourceLoader.LoadOnce("Buildings/" + building.Name);
    GameObject instance = Instantiate(prefab);
    instance.transform.position = building.Position;

    instance.transform.SetParent(transform, false);
  }
}
