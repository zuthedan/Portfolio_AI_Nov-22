#pragma once
#include "Figure.h"
class Knight :
	public Figure
{
public:
	Knight(PlayerColor color) :Figure( color) {}
	void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);
};

