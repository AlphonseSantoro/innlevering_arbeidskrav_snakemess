using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    public class Snake {
        
	    public List<SnakePart> SnakeParts = new List<SnakePart>();

	    private bool _hasEaten = false;
	    private SnakePart _head;
	    private SnakePart _tail;
	    private SnakePart _newHead;

		public Snake(int startX = 10, int startY = 10, int length = 4){
            for (int i = 0; i < length-1; i++){
                AddPart(startX, startY, Markers.BODY);
            }
            AddPart(startX, startY, Markers.HEAD);
        }

		public void Move(MoveDirection direction) {
			_tail = new SnakePart(SnakeParts.First());
			_head = new SnakePart(SnakeParts.Last(), Markers.BODY);
			_newHead = new SnakePart(SnakeParts.Last(), Markers.HEAD);
			switch(direction){
                case MoveDirection.UP:
					_newHead.Coord.Y -= 1;
                    break;
                case MoveDirection.DOWN:
					_newHead.Coord.Y += 1;
				break;
                case MoveDirection.LEFT:
					_newHead.Coord.X -= 1;
				break;
                case MoveDirection.RIGHT:
					_newHead.Coord.X += 1;
				break;
            }
        }
		
	    public bool Collide() {
		    foreach(SnakePart part in SnakeParts) {
			    if(part == _newHead) return true;
		    }
		    if(_newHead.Coord.X < 0 || _newHead.Coord.X >= GameController.windowWidth) {
			    return true;
		    }
		    if(_newHead.Coord.Y < 0	|| _newHead.Coord.Y >= GameController.windowHeight) {
			    return true;
		    }
		    return false;
	    }

	    public void Eat() {
		    _hasEaten = true;
	    }

	    public void DrawSnake() {

		    Console.ForegroundColor = ConsoleColor.Yellow;
		    SnakePart snakePart;

			if(!_hasEaten) {
				SnakeParts.RemoveAt(0);
			    Console.SetCursorPosition(_tail.Coord.X, _tail.Coord.Y);
			    Console.Write(Markers.TAIL);
			} else {
				_hasEaten = false;
			}

			Console.SetCursorPosition(_head.Coord.X, _head.Coord.Y);
		    Console.Write(_head.Icon);

		    snakePart = SnakeParts.ElementAt(SnakeParts.Count - 2);
		    Console.SetCursorPosition(snakePart.Coord.X, snakePart.Coord.Y);
			Console.Write(Markers.BODY);

		    SnakeParts.Add(_newHead);
			Console.ForegroundColor = ConsoleColor.Yellow;
		    Console.SetCursorPosition(_newHead.Coord.X, _newHead.Coord.Y);
		    Console.Write(_newHead.Icon);

		}

		public void AddPart(int x, int y, char marker) {
			SnakeParts.Add(new SnakePart(x, y, marker));
        }

        public bool IsFoodInSnake(Food food) {
            foreach(SnakePart part in SnakeParts){
                if(part == food) return true;
            }
            return false;
        }
    }
}
