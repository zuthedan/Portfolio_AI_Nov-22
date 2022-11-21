#pragma once
#include "Figure.h"
class Pawn :
    public Figure
{
public:
    Pawn( PlayerColor color) :Figure( color) {}
    void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition);
};

