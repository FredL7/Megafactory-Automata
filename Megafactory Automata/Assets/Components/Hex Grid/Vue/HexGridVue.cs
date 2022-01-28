using UnityEngine;

public class HexGridVue : MonoBehaviour {
  [SerializeField] private HexMesh hexMesh;

  private static Color baseColor = new Color(0.8f, 0.8f, 0.8f, 1.0f);

  public void Draw(HexTile[] tiles) {
    hexMesh.Draw(tiles);
  }

  public Color GetColor(HexTile tile) {
    return tile.Color.Mix(baseColor);
  }
}
