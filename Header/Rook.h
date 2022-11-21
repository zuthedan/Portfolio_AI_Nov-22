#pragma once
#include "Figure.h"
class Rook: 
	public Figure
{
public:
	Rook( PlayerColor color) :Figure( color) { hasMoved = false; }
	void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);
	bool GetHasMoved() { return hasMoved; }
	bool MoveToPosition(Position position)
	{
		Figure::CanMoveToPosition(position);
		hasMoved = true;
	}

private:
	bool hasMoved;
};

