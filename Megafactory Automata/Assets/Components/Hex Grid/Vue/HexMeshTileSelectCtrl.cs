using UnityEngine;

public class HexMeshTileSelectCtrl : MonoBehaviour {
  [SerializeField] private Transform hover;

  private Plane plane = new Plane(Vector3.up, 0f);

  private HexCoordinates _current = HexCoordinates.origin;

  private HexGridManager _grid;
  public void SetManagers(HexGridManager grid) { _grid = grid; }

  void Awake() {
    Close();
  }

  public void Open() {
    enabled = true;
  }

  public void Close() {
    hover.gameObject.SetActive(false);
    enabled = false;
  }

  void Update() {
    Vector3 position = GetMousePositionOnFloor();
    HexCoordinates coords = HexCoordinates.FromPosition(position);
    if (_grid.HasTileAt(coords)) {
      if (coords != _current) {
        hover.gameObject.SetActive(true);
        hover.position = coords.WorldPosition;
        _current = coords;
      }
    } else {
      hover.gameObject.SetActive(false);
      _current = coords;
    }
  }

  private Vector3 GetMousePositionOnFloor() {
    //! Twice: here & in TileSelectionCtrl
    float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (plane.Raycast(ray, out distance)) {
      return ray.GetPoint(distance);
    }

    Debug.LogError("Error on raycast to plane");
    return Vector3.zero;
  }
}
