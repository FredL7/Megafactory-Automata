using UnityEngine;

public abstract class Building : ProductionYieldElement/*, IGraphElement*/ {
  /*#region IGraphElement implementation
  private GraphNode _node;
  public GraphNode Node { get { return _node; } }
  public void SetGraphNode(GraphNode node) { _node = node; }
  public Vector3 GetWorldPosition() { return _tile.Position; }
  #endregion*/

  #region HexMap
  public HexTile Tile { get; set; }
  public HexCoordinates Coordinates { get { return Tile.Coordinates; } }
  public Vector3 Position { get { return Tile.Position; } }
  #endregion

  private int _vision = 1;
  public int Vision { get { return _vision; } protected set { _vision = value; } }

  public Building(
    string name, string description, int productionCost,
    Yield yield
  ) : base(name, description, productionCost, yield) { }
}
