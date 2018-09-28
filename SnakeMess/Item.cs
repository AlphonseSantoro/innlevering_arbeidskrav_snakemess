namespace SnakeMess{
  public class Item{
    private Coordinate coordinate{ get; set; }
    private Marker marker{ get; set; }

    public Item(int x, int y, Marker marker){
      this.marker = marker;
      coordinate = new Coordinate(x, y);
    }

    public Item(){
      coordinate = new Coordinate();
    }

    public static bool operator ==(Item item1, Item item2){
      if (item1.coordinate == item2.coordinate) return true;
      return false;
    }

    public static bool operator !=(Item item1, Item item2){
      if (item1.coordinate != item2.coordinate) return true;
      return false;
    }
    
    public int getX(){
      return coordinate.X; 
    }
    
    public int getY(){
      return coordinate.Y; 
    }
  }

  public enum Marker{
    HEAD = '@',
    BODY = '0',
	  TAIL = ' ',
    FOOD = '$'
  }
}
