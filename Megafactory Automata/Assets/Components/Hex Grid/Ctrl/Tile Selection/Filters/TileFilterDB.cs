public class TileFilterDB {
  public ITileFilter districtFilter = new TileFilterGroup(
    new ITileFilter[] {
      new TileFilterHasNotBuilding(), new TileFilterAdjacentToBuilding()
    }
  );
}
