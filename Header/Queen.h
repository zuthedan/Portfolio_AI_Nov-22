#pragma once
#include "Figure.h"
class Queen :
	public Figure
{
public:
	Queen( PlayerColor color):Figure(color){}
	void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);

private: 
	//bool AddMove(Figure* field[8][8], int xCoord, int yCoord);
};

