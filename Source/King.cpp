#include "King.h"
#include "Rook.h"
void King::CalculatePossibleMoves(Figure* field[8][8], Position figurePosition)
{
	possibleMoves.clear();

	int xCoord = figurePosition.xCoord;
	int yCoord = figurePosition.yCoord;
	Figure* fig;
	Position pos;

	// normal movement
	for (int x = -1; x <= 1; x++)
	{
		if (xCoord + x < 0 || xCoord + x>7) continue;

		for (int y = -1; y <= 1; y++)
		{
			if (yCoord + y < 0 || yCoord + y>7) continue;

			pos = Position(xCoord + x, yCoord + y);
			fig = field[pos.xCoord][pos.yCoord];

			if (fig == nullptr || fig->GetColor() != this->color) possibleMoves.push_back(pos);
		}
	}

	// castling
	if (!this->hasMoved)
	{
		Rook* rook;

		// short castling
		fig = field[7][yCoord];

		if (field[5][yCoord] == nullptr && field[6][yCoord] == nullptr && fig != nullptr)
		{
			if (typeid(*fig) == typeid(Rook))
			{
				rook =  (Rook*) fig;
				if (!rook->GetHasMoved()) possibleMoves.push_back(Position(6, yCoord));
			}
		}

		// long castling
		fig = field[0][yCoord];

		if (field[3][yCoord] == nullptr && field[2][yCoord] == nullptr && field[1][yCoord] == nullptr && fig != nullptr)
		{
			if (typeid(*fig)== typeid(Rook))
			{
				rook = (Rook*)fig;
				if (!rook->GetHasMoved()) possibleMoves.push_back(Position(2, yCoord));
			}
		}
	}

	
}

bool King::Move(Figure* field[8][8], Position currentPosition, Position targetPosition)
{
	bool ret = Figure::Move(field, currentPosition, targetPosition);
	Figure* fig;

	// change Rook position when castling
	if (ret && abs(currentPosition.xCoord -targetPosition.xCoord) == 2)
	{
		if (targetPosition.xCoord == 6)
		{
			fig = field[7][targetPosition.yCoord];
			field[5][targetPosition.yCoord] = fig;
			field[7][targetPosition.yCoord] = nullptr;

		}
		else if (targetPosition.xCoord == 2)
		{
			fig = field[0][targetPosition.yCoord];
			field[3][targetPosition.yCoord] = fig;
			field[0][targetPosition.yCoord] = nullptr;
		}
	}
	return ret;
}
std::ostream& operator<<(std::ostream& strm, const King& king)
{
	return strm << "K";
}