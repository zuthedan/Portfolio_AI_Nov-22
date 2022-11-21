#include "Pawn.h"
void Pawn::CalculatePossibleMoves(Figure* field[8][8], Position figurePosition)
{
	int xCoord = figurePosition.xCoord;
	int yCoord = figurePosition.yCoord;
	int forwardDirection;

	possibleMoves.clear();

	switch (color)
	{
	case white:
		forwardDirection = 1;
		break;
	case black:
		forwardDirection = -1;
		break;
	default:
		cout << "Pawn has a wrong Color";
		forwardDirection = 0;
		break;
	}

	if (yCoord + forwardDirection < 8 && yCoord + forwardDirection >=0)
	{

		if (field[xCoord][yCoord + forwardDirection] == nullptr)
		{
			// step forward
			possibleMoves.push_back(Position(xCoord, yCoord + forwardDirection));

			// two steps forward
			if ((yCoord==1||yCoord==6) && yCoord + 2*forwardDirection < 8 && yCoord + 2*forwardDirection >=0&&field[xCoord][ yCoord + 2*forwardDirection] == nullptr)
			{
				possibleMoves.push_back(Position(xCoord, yCoord + 2*forwardDirection));
			}
		}

		// capturing
		for (int i = -1; i <= 1; i += 2)
		{
			if (xCoord + i >= 0 && xCoord + forwardDirection < 8)
			{
				if (field[xCoord + i][yCoord + forwardDirection] != nullptr && field[xCoord + i][yCoord + forwardDirection]->GetColor() != this->color)
				{
					possibleMoves.push_back(Position(xCoord + i, yCoord + forwardDirection));
				}
			}
		}
	}
}

std::ostream& operator<<(std::ostream& strm, const Pawn& pawn)
{
	return strm << "P";
}