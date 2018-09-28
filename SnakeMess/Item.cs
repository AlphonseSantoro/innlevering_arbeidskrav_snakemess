namespace SnakeMess{
  public class Item{
    private Coordinate coordinate;
    private Marker marker{ get; set; }

    public Item(int x, int y, Marker marker){
      this.marker = marker;
      coordinate = new Coordinate(x, y);
    }

    public Item(){
      coordinate = new Coordinate();
    }

    public static bool operator ==(Coordinate cord1, Coordinate cord2){
      if (cord1 == cord2) return true;
      return false;
    }

    public static bool operator !=(Coordinate cord1, Coordinate cord2){
      if (cord1 != cord2) return true;
      return false;
    }
  }

  public enum Marker{
    HEAD = '@',
    PART = '0',
    FOOD = '$'
  }
}
