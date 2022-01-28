using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMeshTileSelect : MonoBehaviour {
  private static float height = HexMetrics.outerRadius * 3f;
  private Vector3 heightDelta = new Vector3(0f, height, 0f);

  private static int _nbSides = 6,
                     _vertPerSide = 4,
                     _triPerSide = 2,
                     _vertPerTri = 3;

  private Mesh _mesh;
  private Vector3[] _vertices;
  private Vector2[] _uvs;
  private int[] _triangles;

  public void Awake() {
    Draw();
  }

  private void Draw() {
    GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
    _mesh.name = "Hex Mesh Highlight";

    _mesh.Clear();

    _vertices = new Vector3[_nbSides * _vertPerSide];
    _uvs = new Vector2[_nbSides * _vertPerSide];
    _triangles = new int[_vertPerTri * _triPerSide * _nbSides];

    DrawSides();

    _mesh.vertices = _vertices;
    _mesh.uv = _uvs;
    _mesh.triangles = _triangles;
    _mesh.RecalculateNormals();
  }

  private void DrawSides() {
    // Vertices
    _vertices[0] = HexMetrics.corners[0];
    _vertices[1] = HexMetrics.corners[0] + heightDelta;
    _vertices[2] = HexMetrics.corners[1];
    _vertices[3] = HexMetrics.corners[1] + heightDelta;
    _vertices[4] = HexMetrics.corners[2];
    _vertices[5] = HexMetrics.corners[2] + heightDelta;
    _vertices[6] = HexMetrics.corners[3];
    _vertices[7] = HexMetrics.corners[3] + heightDelta;
    _vertices[8] = HexMetrics.corners[4];
    _vertices[9] = HexMetrics.corners[4] + heightDelta;
    _vertices[10] = HexMetrics.corners[5];
    _vertices[11] = HexMetrics.corners[5] + heightDelta;

    // UVs
    _uvs[0] = Vector2.up;
    _uvs[1] = Vector2.zero;
    _uvs[2] = Vector2.up;
    _uvs[3] = Vector2.zero;
    _uvs[4] = Vector2.up;
    _uvs[5] = Vector2.zero;
    _uvs[6] = Vector2.up;
    _uvs[7] = Vector2.zero;
    _uvs[8] = Vector2.up;
    _uvs[9] = Vector2.zero;
    _uvs[10] = Vector2.up;
    _uvs[11] = Vector2.zero;

    // Triangles
    for (int i = 0; i < _nbSides - 1; ++i) {
      _triangles[i * _vertPerTri * _triPerSide + 0] = i * 2 + 0;
      _triangles[i * _vertPerTri * _triPerSide + 1] = i * 2 + 1;
      _triangles[i * _vertPerTri * _triPerSide + 2] = i * 2 + 2;

      _triangles[i * _vertPerTri * _triPerSide + 3] = i * 2 + 2;
      _triangles[i * _vertPerTri * _triPerSide + 4] = i * 2 + 1;
      _triangles[i * _vertPerTri * _triPerSide + 5] = i * 2 + 3;
    }
    // Fix for last side
    _triangles[5 * _vertPerTri * _triPerSide + 0] = 10;
    _triangles[5 * _vertPerTri * _triPerSide + 1] = 11;
    _triangles[5 * _vertPerTri * _triPerSide + 2] = 0;

    _triangles[5 * _vertPerTri * _triPerSide + 3] = 0;
    _triangles[5 * _vertPerTri * _triPerSide + 4] = 11;
    _triangles[5 * _vertPerTri * _triPerSide + 5] = 1;
  }
}
