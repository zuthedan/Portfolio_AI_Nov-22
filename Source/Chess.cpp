#include <iostream>
#include <Windows.h>

#include "Bishop.h"
#include "Figure.h"
#include "King.h"
#include "Knight.h"
#include "Pawn.h"
#include "Queen.h"
#include "Rook.h"

using namespace std;

struct Move
{
public:
    Position selectedFigure;
    Position nextField;
    Move(Position selectedFigure, Position nextField)
    {
        this->selectedFigure = selectedFigure;
        this->nextField = nextField;
    }

    Move() { selectedFigure = {}; nextField = {}; }
};

const int GREY_BACK_BLACK_TEXT = 128;
const int GREY_BACK_WHITE_TEXT = 143;
const int BLACK_BACK_WHITE_TEXT = 15;
const int GREY_BACK_GREY_TEXT = 135;
const int GOLD_BACK_GREY_TEXT = 104;

Move currentMove;
PlayerColor currentPlayer;
HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
bool gameIsRunning = true;

void Fill(Figure* field[8][8]) 
{
    PlayerColor color;
    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            if (y < 2) color = PlayerColor::white;
            if (y > 5) color = PlayerColor::black;

            switch (y)
            {
            case 1:
            case 6:
                field[x][y] = new Pawn(color);
                break;
            case 0:
            case 7:
                switch (x)
                {
                case 0:
                case 7:
                    field[x][y] = new Rook( color);
                    break;

                case 1:
                case 6:

                    field[x][y] = new Knight( color);
                    break;

                case 2:
                case 5:

                    field[x][y] = new Bishop(color);
                    break;

                case 3:
                    field[x][y] = new Queen(color);
                    break;

                case 4:
                    field[x][y] = new King( color);                    
                    break;
                }
                break;
            default:
                field[x][y] = nullptr;
                break;
            }
        }
    }
}

int FieldCharToInt(char c) 
{
    c = (char)tolower(c);
    switch (c)
    {
    case 'a':
        return 0;

    case 'b':
        return 1;

    case 'c':
        return 2;

    case 'd':
        return 3;

    case 'e':
        return 4;

    case 'f':
        return 5;

    case 'g':
        return 6;

    case 'h':
        return 7;

    default:
        return -1;
    }
}

char FieldIntToChar(int i)
{
    switch (i)
    {
    case 0:
        return 'A';

    case 1:
        return 'B';

    case 2:
        return 'C';

    case 3:
        return 'D';

    case 4:
        return 'E';

    case 5:
        return 'F';

    case 6:
        return 'G';

    case 7:
        return 'H';

    default:
        return '?';
    }
}

/// <summary>
/// reads the next input as a new Position
/// </summary>
/// <returns> Position(-1,-1) if input could not be read </returns>
Position ReadMove() 
{
    string input;
    int positions[2];

    cin >> input;

    if (input.length() != 2 ) return Position();

    positions[0] = FieldCharToInt(input[0]);
    positions[1] = atoi(&input[1]);

    if (positions[0] < 0 || positions[0] >7 || positions[1] < 1 || positions[1]>8) return Position();

    return Position(positions[0], positions[1]-1);
}

/// <summary>
/// returns the character representing the given Figure
/// </summary>
/// <param name="fig"> the Figure that should be represented </param>
/// <returns> '?' if Figure is nullptr </returns>
char GetFigureCharacter(Figure* fig)
{
    char figureString;
    if (fig == nullptr)
    {
        cout << "ERROR: Character couldn't be determined, Figure was nullptr";
        return '?';
    }

    if (typeid(*fig) == typeid(Rook)) figureString = 'R';
    else if (typeid(*fig) == typeid(King)) figureString = 'K';
    else if (typeid(*fig) == typeid(Knight)) figureString = 'N';
    else if (typeid(*fig) == typeid(Queen)) figureString = 'Q';
    else if (typeid(*fig) == typeid(Bishop)) figureString = 'B';
    else if (typeid(*fig) == typeid(Pawn)) figureString = 'P';

    return figureString;
}

void DrawGameField(Figure* field[8][8], Position* selectedPos) 
{
    Figure* selectedFigure = nullptr;
    bool colorChanged = false;

    if (selectedPos != nullptr)
    {
        selectedFigure = field[selectedPos->xCoord][selectedPos->yCoord];
        selectedFigure->CalculatePossibleMoves(field, *selectedPos);
    }


    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            // possible move
            if (selectedFigure != nullptr && selectedFigure->CanMoveToPosition(Position(x, y)))
            {
                SetConsoleTextAttribute(hConsole, GOLD_BACK_GREY_TEXT);
                colorChanged = true;
            }

            // empty field
            if (field[x][y] == nullptr)
            {
                if(!colorChanged) SetConsoleTextAttribute(hConsole, GREY_BACK_GREY_TEXT);
                cout << "  ";
            }            
            else // figure field
            { 
                if (!colorChanged)
                {
                    field[x][y]->GetColor() == PlayerColor::black ? SetConsoleTextAttribute(hConsole, GREY_BACK_BLACK_TEXT) : SetConsoleTextAttribute(hConsole, GREY_BACK_WHITE_TEXT);
                }
                cout << GetFigureCharacter(field[x][y]);

                // selected figure
                if (selectedPos != nullptr && selectedPos->xCoord == x && selectedPos->yCoord == y)
                {
                    cout << "*";
                }
                else // not selected figure
                {
                    cout << " ";
                }

            }
            SetConsoleTextAttribute(hConsole, BLACK_BACK_WHITE_TEXT);
            colorChanged = false;
            cout << "  ";
        }

        cout << "   " << y+1;
        cout << endl<< endl;
    }

    cout << endl << endl << "A   B   C   D   E   F   G   H" << endl;
}

void HandlePawnChange(Figure* field[8][8], Position targetPosition)
{
    char input=' ';

    // makes sure the input is legal
    do
    {
        system("cls");
        DrawGameField(field, nullptr);

        cout << "Choose the type of Figure the Pawn changes to:" << endl
            << "B - Bishop" << endl
            << "N - Knight" << endl
            << "R - Rook" << endl
            << "Q - Queen" << endl;

        cin >> input;
        input = tolower(input);

    }while(input != 'q' && input!= 'r' && input!= 'n' && input != 'b');

    // changes the pawn to the new figure
    switch (input)
    {
    case 'q':
        field[targetPosition.xCoord][targetPosition.yCoord] =new  Queen(currentPlayer);
        break;
    case 'r':
        field[targetPosition.xCoord][targetPosition.yCoord] = new  Rook(currentPlayer);
        break;
    case 'n':
        field[targetPosition.xCoord][targetPosition.yCoord] = new  Knight(currentPlayer);
        break;
    case 'b':
        field[targetPosition.xCoord][targetPosition.yCoord] = new  Bishop(currentPlayer);
        break;
    }
}


int main()
{
    Figure* field[8][8];
    Figure* selectedFigure;
    Figure* targetFigure;

    Position pos = {};

    Fill(field);

    while (gameIsRunning)
    {

        system("cls");
        DrawGameField(field, nullptr);

        cout << endl << (currentPlayer == PlayerColor::white ? "White" : "Black") << " is turn player" << endl << "Please enter a new Move by typing the Letter and Number of the Field you want to select" << endl;

        // select figure
        {
            pos = ReadMove();
            if (pos.xCoord == -1 || pos.yCoord == -1)continue;

            if (field[pos.xCoord][pos.yCoord] == nullptr || field[pos.xCoord][pos.yCoord]->GetColor() != currentPlayer) continue;

            currentMove = Move(pos, {});
        }


        system("cls");
        DrawGameField(field, &pos);

        cout << endl << FieldIntToChar(pos.xCoord) << pos.yCoord+1 << " is selected"<<endl<< "Please enter a new Move by typing the Letter and Number of the Field you want the Figure to move to" << endl;

        // select target field
        {
            pos = ReadMove();
            if (pos.xCoord == -1 || pos.yCoord == -1)continue;

            currentMove = Move(currentMove.selectedFigure, pos);
        }

        // move figure if possible
        {
            selectedFigure = field[currentMove.selectedFigure.xCoord][currentMove.selectedFigure.yCoord];
            targetFigure = field[currentMove.nextField.xCoord][currentMove.nextField.yCoord];

            if (selectedFigure->Move(field, currentMove.selectedFigure, currentMove.nextField))
            {
                
                    // pawn change
                    if (typeid(*selectedFigure) == typeid(Pawn) && (currentMove.nextField.yCoord == 7 || currentMove.nextField.yCoord == 0))HandlePawnChange(field, currentMove.nextField);

                    // player captured King => game ends
                    if (targetFigure != nullptr) gameIsRunning = typeid(*targetFigure) != typeid(King);

                // switch currentPlayer
                currentPlayer = currentPlayer == PlayerColor::black ? PlayerColor::white : PlayerColor::black;
            }

            currentMove = {};
        }

    }

    cout << "The game ended" << endl
        << "Player " << (currentPlayer == PlayerColor::white ? "black" : "white") << " won" << endl;

    return 0;

}
