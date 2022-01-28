using System;
using System.Collections;

public enum EHexDirections { NE, NW, W, SW, SE, E }

public static class HexDirectionsExtension {
  public static IEnumerable Values() {
    return Enum.GetValues(typeof(EHexDirections));
  }

  public static HexCoordinates ToCoordinates(this EHexDirections direction) {
    switch (direction) {
      case EHexDirections.NE: return HexCoordinates.NE;
      case EHexDirections.NW: return HexCoordinates.NW;
      case EHexDirections.W: return HexCoordinates.W;
      case EHexDirections.SW: return HexCoordinates.SW;
      case EHexDirections.SE: return HexCoordinates.SE;
      case EHexDirections.E: return HexCoordinates.E;
    }

    UnityEngine.Debug.LogError("Hexdirection " + direction + " not found");
    return HexCoordinates.origin;
  }
}
