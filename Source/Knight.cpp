#include "Knight.h"
void Knight::CalculatePossibleMoves(Figure* field[8][8], Position figurePosition)
{
	possibleMoves.clear();
	Position pos = {};
	Figure* fig=nullptr;

	for (int x = -2; x <= 2; x++)
	{

		if (figurePosition.xCoord + x < 0 || figurePosition.xCoord + x>7) continue;

		for (int y = -2; y <= 2; y++)
		{
			if (figurePosition.yCoord + y < 0 || figurePosition.yCoord + y>7) continue;

			pos = Position(figurePosition.xCoord + x, figurePosition.yCoord + y);

			fig = field[pos.xCoord][pos.yCoord];

			if (x!=0 && y!= 0 &&abs(x) != abs(y) && (fig == nullptr || fig->GetColor() != this->color))
			{
				possibleMoves.push_back(pos);
			}

		}
	}
}

std::ostream& operator<<(std::ostream& strm, const Knight& knight)
{
	return strm << "N";
}