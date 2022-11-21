#pragma once
#include "Figure.h"
class Bishop :
	public Figure
{
public:
	Bishop(PlayerColor color) :Figure( color) {}
	void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);
};

