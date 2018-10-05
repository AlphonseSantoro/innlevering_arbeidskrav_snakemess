using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class Snake {
        
	    public List<SnakePart> SnakeParts = new List<SnakePart>();

	    private bool hasEaten = false;
	    private SnakePart head;
	    private SnakePart tail;
	    private SnakePart newHead;

		public Snake(int startX = 10, int startY = 10, int length = 4){
            for (int i = 0; i < length-1; i++){
                AddPart(startX, startY, Markers.BODY);
            }
            AddPart(startX, startY, Markers.HEAD);
        }

		public void Move(MoveDirection direction) {
			tail = new SnakePart(SnakeParts.First());
			head = new SnakePart(SnakeParts.Last(), Markers.BODY);
			newHead = new SnakePart(SnakeParts.Last(), Markers.HEAD);
			switch(direction){
                case MoveDirection.UP:
					newHead.Coord.Y -= 1;
                    break;
                case MoveDirection.DOWN:
					newHead.Coord.Y += 1;
				break;
                case MoveDirection.LEFT:
					newHead.Coord.X -= 1;
				break;
                case MoveDirection.RIGHT:
					newHead.Coord.X += 1;
				break;
            }
        }
		
	    public bool Collide() {
		    foreach(SnakePart part in SnakeParts) {
			    if(part == newHead) return true;
		    }
		    if(newHead.Coord.X < 0 || newHead.Coord.X >= GameController.windowWidth) {
			    return true;
		    }
		    if(newHead.Coord.Y < 0	|| newHead.Coord.Y >= GameController.windowHeight) {
			    return true;
		    }
		    return false;
	    }

	    public void Eat() {
		    hasEaten = true;
	    }

	    public void DrawSnake() {

		    Console.ForegroundColor = ConsoleColor.Yellow;
		    SnakePart sp;

			if(!hasEaten) {
				SnakeParts.RemoveAt(0);
			    Console.SetCursorPosition(tail.Coord.X, tail.Coord.Y);
			    Console.Write(Markers.TAIL);
			} else {
				hasEaten = false;
			}

			Console.SetCursorPosition(head.Coord.X, head.Coord.Y);
		    Console.Write(head.icon);

		    sp = SnakeParts.ElementAt(SnakeParts.Count - 2);
		    Console.SetCursorPosition(sp.Coord.X, sp.Coord.Y);
			Console.Write(Markers.BODY);

		    SnakeParts.Add(newHead);
			Console.ForegroundColor = ConsoleColor.Yellow;
		    Console.SetCursorPosition(newHead.Coord.X, newHead.Coord.Y);
		    Console.Write(newHead.icon);

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
