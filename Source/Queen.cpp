#include "Queen.h"
void Queen::CalculatePossibleMoves(Figure* field[8][8], Position figurePosition)
{
	Figure* fig;
	int directionCounter;
	int xCoord = figurePosition.xCoord;
	int yCoord = figurePosition.yCoord;

	possibleMoves.clear();

	for (int dir = MovementDirection::forward; dir <= MovementDirection::forwardLeft; dir++)
	{
		directionCounter = 1;
		switch (dir)
		{

		case MovementDirection::forward: // +y

			while (yCoord + directionCounter < 8)
			{
				if (!AddMove(field, xCoord, yCoord + directionCounter)) break;
				directionCounter++;
			}

			break;

		case MovementDirection::back: // -y

			while (yCoord - directionCounter >= 0)
			{
				if (!AddMove(field, xCoord, yCoord - directionCounter)) break;
				directionCounter++;
			}

			break;

		case MovementDirection::right: // +x

			while (xCoord + directionCounter < 8)
			{
				if (!AddMove(field, xCoord+directionCounter, yCoord)) break;
				directionCounter++;
			}

			break;

		case MovementDirection::left: // -x

			while (xCoord - directionCounter >= 0)
			{
				if (!AddMove(field, xCoord-directionCounter, yCoord)) break;
				directionCounter++;
			}

			break;

		case MovementDirection::forwardRight: // +x, +y

			while (xCoord + directionCounter < 8 && yCoord + directionCounter < 8)
			{
				if (!AddMove(field, xCoord+directionCounter, yCoord + directionCounter)) break;
				directionCounter++;
			}
			break;

		case MovementDirection::backRight: // +x, -y

			while (xCoord + directionCounter <8 && yCoord - directionCounter >=0)
			{
				if (!AddMove(field, xCoord+directionCounter, yCoord - directionCounter)) break;
				directionCounter++;
			}
			break;

		case MovementDirection::backLeft: // -x, -y

			while (xCoord - directionCounter >= 0 && yCoord - directionCounter >= 0)
			{
				if (!AddMove(field, xCoord-directionCounter, yCoord - directionCounter)) break;
				directionCounter++;
			}
			break;

		case MovementDirection::forwardLeft: // -x, +y

			while (xCoord - directionCounter >=0 && yCoord + directionCounter <8)
			{
				if (!AddMove(field, xCoord-directionCounter, yCoord + directionCounter)) break;
				directionCounter++;
			}
			break;
		default:

			std::cout << "Queen has a wrong MovementDirection";
			break;
		}


	}
}

std::ostream& operator<<(std::ostream& strm, const Queen& queen)
{
	return strm << "Q";
}