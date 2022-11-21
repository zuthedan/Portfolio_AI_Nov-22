#include "Figure.h"

/// <summary>
/// Adds a single Position to the possibleMoves if it is possible and returns whether or not it is possible to continue in this direction
/// </summary>
/// <param name="field"> the current game state </param>
/// <param name="xCoord"> the new x-Position </param>
/// <param name="yCoord"> the new y-Position </param>
/// <returns> true == can continue in this direction, false == cannot continue in this direction </returns>
bool Figure::AddMove(Figure* field[8][8], int xCoord, int yCoord)
{
	Figure* fig = field[xCoord][yCoord];

	if (fig != nullptr && fig->GetColor() == this->color) return false;

	possibleMoves.push_back(Position(xCoord, yCoord));

	if (fig != nullptr) return false;

	return true;
}

/// <summary>
/// checks whether a Position is a valid move for the Figure
/// </summary>
/// <param name="position"> the new Position </param>
/// <returns> true == can move there, false == cannot move there </returns>
bool Figure::CanMoveToPosition(Position position)
{
	bool isPossible = false;

	for (Position pos : possibleMoves)
	{
		if (pos.xCoord == position.xCoord && pos.yCoord == position.yCoord)
		{
			isPossible = true;
			break;
		}
	}

	return isPossible;
}

/// <summary>
/// moves a Figure to a new Position
/// </summary>
/// <param name="field"> the current game state </param>
/// <param name="currentPosition"> the Position of the Figure </param>
/// <param name="targetPosition"> the new Position </param>
/// <returns> true == Figure was moved, false == Figure wasn't moved </returns>
bool Figure::Move(Figure* field[8][8], Position currentPosition, Position targetPosition)
{
	CalculatePossibleMoves(field, currentPosition);
	if (CanMoveToPosition(targetPosition))
	{
		hasMoved = true;
			field[targetPosition.xCoord][targetPosition.yCoord] = this;
		field[currentPosition.xCoord][currentPosition.yCoord] = nullptr;
		return true;
	}
	return false;
}
