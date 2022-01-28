using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
  private static Color baseColor = new Color(0.8f, 0.8f, 0.8f, 1.0f);

  private static int _vertPerTile = 7, _triPerTile = 6, _vertPerTri = 3;

  private Mesh _mesh;
  private Vector3[] _vertices;
  private Vector2[] _uvs;
  private Color[] _colors;
  private int[] _triangles;

  //! Might fail at around 9300 tiles (2^16 / 7 vertices per tile) --> 65536

  public void Erase() {
    if (_mesh != null)
      _mesh.Clear();
    GetComponent<MeshFilter>().mesh = _mesh = null;
  }

  public void Draw(HexTile[] tiles) {
    GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
    _mesh.name = "Hex Mesh Highlight";

    _mesh.Clear();

    _vertices = new Vector3[_vertPerTile * tiles.Length];
    _uvs = new Vector2[_vertPerTile * tiles.Length];
    _colors = new Color[_vertPerTile * tiles.Length];
    _triangles = new int[_vertPerTri * _triPerTile * tiles.Length];

    for (int i = 0; i < tiles.Length; ++i)
      MakeHexagon(tiles[i], i);

    _mesh.vertices = _vertices;
    _mesh.uv = _uvs;
    _mesh.colors = _colors;
    _mesh.triangles = _triangles;
    _mesh.RecalculateNormals();
  }

  void MakeHexagon(HexTile tile, int index) {
    Vector3 center = tile.Position;

    // 7 Vertices per tile
    _vertices[index * _vertPerTile + 0] = center;
    _vertices[index * _vertPerTile + 1] = center + HexMetrics.corners[0];
    _vertices[index * _vertPerTile + 2] = center + HexMetrics.corners[1];
    _vertices[index * _vertPerTile + 3] = center + HexMetrics.corners[2];
    _vertices[index * _vertPerTile + 4] = center + HexMetrics.corners[3];
    _vertices[index * _vertPerTile + 5] = center + HexMetrics.corners[4];
    _vertices[index * _vertPerTile + 6] = center + HexMetrics.corners[5];

    // UVs
    _uvs[index * _vertPerTile + 0] = new Vector2(0f, 0f);
    _uvs[index * _vertPerTile + 1] = new Vector2(0f, 1f);
    _uvs[index * _vertPerTile + 2] = new Vector2(0f, 1f);
    _uvs[index * _vertPerTile + 3] = new Vector2(0f, 1f);
    _uvs[index * _vertPerTile + 4] = new Vector2(0f, 1f);
    _uvs[index * _vertPerTile + 5] = new Vector2(0f, 1f);
    _uvs[index * _vertPerTile + 6] = new Vector2(0f, 1f);

    // Triangles for tiles
    for (int i = 0; i < 6; ++i) {
      _triangles[index * _triPerTile * _vertPerTri + i * 3 + 0] = index * _vertPerTile;
      _triangles[index * _triPerTile * _vertPerTri + i * 3 + 1] = index * _vertPerTile + (i + 1);
      _triangles[index * _triPerTile * _vertPerTri + i * 3 + 2] = index * _vertPerTile + ((i + 2) % 7);
    }
    // Fix for last triangle wrap-around (modulo above doesn't seem to fix it)
    _triangles[index * _triPerTile * _vertPerTri + 5 * 3 + 2] = index * _vertPerTile + 1;

    // Color
    for (int i = 0; i < _vertPerTile; ++i)
      _colors[index * _vertPerTile + i] = tile.Color.Mix(baseColor);
  }
}
