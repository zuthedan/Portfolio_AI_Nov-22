#pragma once
#include <list>
#include <iostream>


using namespace std;

struct Position
{
public:
	int xCoord;
	int yCoord;
	Position(int xCoord, int yCoord) { this->xCoord = xCoord; this->yCoord=yCoord; }
	Position() { this->xCoord = -1; this->yCoord = -1; }
};

enum PlayerColor
{
	white,black
};

enum MovementDirection
{
	forward, right, back, left, forwardRight, backRight, backLeft, forwardLeft
};

class Figure abstract
{
protected:
	PlayerColor color;
	bool hasMoved;

	std::list<Position> possibleMoves;
	
	Figure(PlayerColor color) { this->color = color; this->possibleMoves = std::list<Position>(); this->hasMoved = false; }

	bool AddMove(Figure* field[8][8], int xCoord, int yCoord);
	
public:
	PlayerColor GetColor() { return this->color; }
	virtual void CalculatePossibleMoves(Figure* field[8][8], Position figurePosition)=0;
	bool CanMoveToPosition(Position position);
	virtual bool Move(Figure* field[8][8], Position currentPosition, Position targetPosition);
};

