#pragma once
#include "Figure.h"
class King :
    public Figure
{


public:
    King(PlayerColor color) :Figure( color) { hasMoved = false; }
	void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);
    bool Move(Figure* field[8][8], Position currentPosition, Position targetPosition);

};

