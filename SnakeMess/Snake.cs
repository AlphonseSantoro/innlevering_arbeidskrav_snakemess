using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    public class Snake {
        
	    public List<SnakePart> SnakeParts = new List<SnakePart>();

	    private readonly ConsoleColor _snakeColor = ConsoleColor.Yellow;
	    private bool _hasEaten = false;
	    private SnakePart _head;
	    private SnakePart _tail;
	    private SnakePart _newHead;

		public Snake(int startX = 10, int startY = 10, int length = 4){
			//Add body parts to make the snake longer
            for (int i = 0; i < length-1; i++){
                AddPart(startX, startY, Marker.BODY);
            }
			//Add the head last
            AddPart(startX, startY, Marker.HEAD);
        }

		//Move the snake by creating a new head and move it by 1 character
		// in a set direction depending on player input.
		public void Move(MoveDirection direction) {
			_tail = new SnakePart(SnakeParts.First(), Marker.TAIL); //First element, or last snake body part
			_head = new SnakePart(SnakeParts.Last(), Marker.BODY); //Last "newHead"
			_newHead = new SnakePart(SnakeParts.Last(), Marker.HEAD); //Same as head, but will be moved
			//Move the _newHead to create a motion
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
		
		//Check if the snake is colliding with anything
	    public bool Collide() {
			//Loop to check collision with itself
		    foreach(SnakePart part in SnakeParts) {
			    if(part == _newHead) return true;
		    }
			//Check if the _newHead position is colliding with the console walls
		    if(_newHead.Coord.X < 0 || _newHead.Coord.X >= GameController.windowWidth) {
			    return true;
		    }
		    if(_newHead.Coord.Y < 0	|| _newHead.Coord.Y >= GameController.windowHeight) {
			    return true;
		    }
		    return false;
	    }

		//The snake is over a food object, so it will eat it
	    public void Eat() {
		    _hasEaten = true;
	    }

		//Draw the snake
	    public void DrawSnake() {

			//Color of the snake
		    Output.SetColor(_snakeColor);

			//Check if snake has eaten or not since the last move
			if(!_hasEaten) {
				//If false, remove a snake part to stop it from growing
				SnakeParts.RemoveAt(0);
				//Draw a "empty" space on last element
				Output.Draw(_tail.Coord.X, _tail.Coord.Y, _tail.Icon);
			} else {
				//If the snake ate last step, it has now not eaten anymore :)
				_hasEaten = false;
			}

			//Draw last head as body part
			Output.Draw(_head.Coord.X, _head.Coord.Y, _head.Icon);

			//Add the new head to the snake
		    SnakeParts.Add(_newHead);
			Output.Draw(_newHead.Coord.X, _newHead.Coord.Y, _newHead.Icon);

		}

		//Add a new part to the snake
		public void AddPart(int x, int y, Marker marker) {
			SnakeParts.Add(new SnakePart(x, y, marker));
        }

		//Check if the snake head is over food
        public bool IsFoodInSnake(Food food) {
            foreach(SnakePart part in SnakeParts){
                if(part == food) return true;
            }
            return false;
        }
    }
}
