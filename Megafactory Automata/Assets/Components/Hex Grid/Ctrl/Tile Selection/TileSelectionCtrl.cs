using UnityEngine;

public class TileSelectionCtrl : MonoBehaviour {
  [SerializeField] private TileSelectionVue vue;

  private TileFilterDB filterDB = new TileFilterDB();

  private HexGridManager _grid;
  public void SetManagers(HexGridManager grid) { _grid = grid; }

  private Plane plane = new Plane(Vector3.up, 0f);
  private Vector3 downPosition = Vector3.zero;
  private Vector3 upPosition = Vector3.zero;

  private ITileSelectionCallback _callback;

  void Awake() {
    CloseVues();
  }

  private void OpenVues() {
    enabled = true;
    vue.Draw(
      _grid.TileList, _grid,
      filterDB.districtFilter
    );
  }

  private void CloseVues() {
    enabled = false;
    vue.Erase();
  }

  // TODO: Add tile filter(s) (i.e. available for construction, adjacent to other building, etc.)
  public void BeginSelection(ITileSelectionCallback callback) {
    _callback = callback;
    OpenVues();
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      downPosition = GetMousePositionOnFloor();
    } else if (Input.GetMouseButtonUp(0)) {
      upPosition = GetMousePositionOnFloor();
      HandleTouch();
    }
  }

  private Vector3 GetMousePositionOnFloor() {
    //! Twice: here & in HexMeshTileSelectCtrl
    float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (plane.Raycast(ray, out distance)) {
      return ray.GetPoint(distance);
    }

    Debug.LogError("Error on raycast to plane");
    return Vector3.zero;
  }

  private void HandleTouch() {
    HexCoordinates downCoord = HexCoordinates.FromPosition(downPosition);
    HexCoordinates upCoord = HexCoordinates.FromPosition(upPosition);
    if (downCoord != upCoord) {
      Debug.Log("Touch failed, coordinates are not the same: " + downCoord.ToPrettyString() + " - " + upCoord.ToPrettyString());
    } else if (_grid.HasTileAt(downCoord) && _grid.HasTileAt(upCoord)) {
      HexTile tile = _grid.GetTileAt(downCoord);
      if (ValidateTile(tile))
        FinishSelection(tile);
    }
  }

  private bool ValidateTile(HexTile tile) {
    return filterDB.districtFilter.Valid(tile, _grid);
  }

  private void FinishSelection(HexTile tile) {
    CloseVues();
    _callback.OnTileSelection(tile);
    _callback = null;
  }
}
