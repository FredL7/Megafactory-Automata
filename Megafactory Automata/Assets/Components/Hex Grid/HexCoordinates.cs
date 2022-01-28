using System.Collections.Generic;
using UnityEngine;

public struct HexCoordinates {
  public static HexCoordinates
    origin = new HexCoordinates(0, 0),
    NE = new HexCoordinates(0, 1),
    NW = new HexCoordinates(-1, 1),
    W = new HexCoordinates(-1, 0),
    SW = new HexCoordinates(0, -1),
    SE = new HexCoordinates(1, -1),
    E = new HexCoordinates(1, 0);

  private int x, z;
  public int X { get { return x; } }
  public int Z { get { return z; } }
  public int Y { get { return -x - z; } }

  public Vector3 WorldPosition {
    get {
      Vector3 position;

      position.x = (x + z * 0.5f/* - z / 2*/) * (HexMetrics.innerRadius * 2f);
      position.y = 0f;
      position.z = z * (HexMetrics.outerRadius * 1.5f);

      return position;
    }
  }

  public HexCoordinates(int x, int z) {
    this.x = x; this.z = z;
  }

  public static HexCoordinates FromOffsetCoordinates(int x, int z) {
    return new HexCoordinates(x - z / 2, z);
  }

  public static HexCoordinates FromPosition(Vector3 position) {
    float x = position.x / (HexMetrics.innerRadius * 2f);
    float y = -x;

    float offset = position.z / (HexMetrics.outerRadius * 3f);
    x -= offset;
    y -= offset;

    int iX = Mathf.RoundToInt(x);
    int iY = Mathf.RoundToInt(y);
    int iZ = Mathf.RoundToInt(-x - y);

    if (iX + iY + iZ != 0) {
      float dX = Mathf.Abs(x - iX);
      float dY = Mathf.Abs(y - iY);
      float dZ = Mathf.Abs(-x - y - iZ);

      if (dX > dY && dX > dZ) {
        iX = -iY - iZ;
      } else if (dZ > dY) {
        iZ = -iX - iY;
      }
    }

    return new HexCoordinates(iX, iZ);
  }

  public static List<HexCoordinates> GetNeighbourCoordinates(HexCoordinates origin) {
    return GetCoordinatesAround(origin, 1);
  }

  public static List<HexCoordinates> GetCoordinatesAround(HexCoordinates origin, int radius) {
    List<HexCoordinates> coordinates = new List<HexCoordinates>();

    for (int z = -radius; z <= radius; ++z) {
      for (int x = -radius; x <= radius; ++x) {
        HexCoordinates coord = new HexCoordinates(x, z);
        if (Mathf.Abs(coord.X) + Mathf.Abs(coord.Y) + Mathf.Abs(coord.Z) <= 2 * radius)
          coordinates.Add(origin + coord);
      }
    }

    return coordinates;
  }

  public override bool Equals(object obj) => obj is HexCoordinates other && this.Equals(other);
  public bool Equals(HexCoordinates coordinates) => x == coordinates.x && z == coordinates.z;
  public override int GetHashCode() => x * 1000 + z;

  public static bool operator ==(HexCoordinates a, HexCoordinates b) => a.x == b.x && a.z == b.z;
  public static bool operator !=(HexCoordinates a, HexCoordinates b) => a.x != b.x || a.z != b.z;

  public static HexCoordinates operator +(HexCoordinates a, HexCoordinates b) => new HexCoordinates(a.x + b.x, a.z + b.z);
  public static HexCoordinates operator -(HexCoordinates a, HexCoordinates b) => new HexCoordinates(a.x - b.x, a.z - b.z);

  public string ToPrettyString() { return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")"; }
}
