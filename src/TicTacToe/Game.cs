namespace TicTacToe;

//TODO: smell Lazy Class
public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }

    public bool TileEqualsByCoordinates(int x, int y)
    {
        return X == x && Y == y;
    }
}

//TODO: smell Lazy Class
//TODO: smell Feature Envy
//TODO: smell Data Clumps
//TODO: smell Shotgun Surgery
//TODO: smell Primitive Obsession
public class Board
{
    private readonly List<Tile> _plays = new();

    public Board()
    {
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                _plays.Add(new Tile {X = i, Y = j, Symbol = ' '});
            }
        }
    }

    public Tile TileAt(int x, int y)
    {
        return _plays.Single(tile => tile.TileEqualsByCoordinates(x, y));
    }

    //TODO: smell Duplicated Code
    //TODO: smell Message Chain
    //TODO: smell Dead Code
    //TODO: smell Long Parameter List
    public void AddTileAt(char symbol, int x, int y)
    {
        var newTile = new Tile {X = x, Y = y, Symbol = symbol};

        _plays.Single(tile => tile.TileEqualsByCoordinates(x, y)).Symbol = symbol;
    }
}

//TODO: smell Large Class
//TODO: smell Feature Envy
//TODO: smell Data Clumps
//TODO: smell Shotgun Surgery
//TODO: smell Primitive Obsession
//TODO: smell Comments
//TODO: smell Message Chain
public class Game
{
    private readonly Board _board = new();
    private char _lastSymbol = ' ';

    //TODO: smell Long Parameter List
    //TODO: smell Long Method
    public void Play(char symbol, int x, int y)
    {
        //if first move
        if (_lastSymbol == ' ')
        {
            //if player is X
            if (symbol == 'O')
            {
                throw new Exception("Invalid first player");
            }
        }
        //if not first move but player repeated
        else if (symbol == _lastSymbol)
        {
            throw new Exception("Invalid next player");
        }
        //if not first move but play on an already played tile
        else if (_board.TileAt(x, y).Symbol != ' ')
        {
            throw new Exception("Invalid position");
        }

        // update game state
        _lastSymbol = symbol;
        _board.AddTileAt(symbol, x, y);
    }

    public char Winner()
    {
        //if the positions in first row are taken
        if (_board.TileAt(0, 0).Symbol != ' ' &&
            _board.TileAt(0, 1).Symbol != ' ' &&
            _board.TileAt(0, 2).Symbol != ' ')
        {
            //if first row is full with same symbol
            if (_board.TileAt(0, 0).Symbol ==
                _board.TileAt(0, 1).Symbol &&
                _board.TileAt(0, 2).Symbol ==
                _board.TileAt(0, 1).Symbol)
            {
                return _board.TileAt(0, 0).Symbol;
            }
        }

        //if the positions in first row are taken
        if (_board.TileAt(1, 0).Symbol != ' ' &&
            _board.TileAt(1, 1).Symbol != ' ' &&
            _board.TileAt(1, 2).Symbol != ' ')
        {
            //if middle row is full with same symbol
            if (_board.TileAt(1, 0).Symbol ==
                _board.TileAt(1, 1).Symbol &&
                _board.TileAt(1, 2).Symbol ==
                _board.TileAt(1, 1).Symbol)
            {
                return _board.TileAt(1, 0).Symbol;
            }
        }

        //if the positions in first row are taken
        if (_board.TileAt(2, 0).Symbol != ' ' &&
            _board.TileAt(2, 1).Symbol != ' ' &&
            _board.TileAt(2, 2).Symbol != ' ')
        {
            //if middle row is full with same symbol
            if (_board.TileAt(2, 0).Symbol ==
                _board.TileAt(2, 1).Symbol &&
                _board.TileAt(2, 2).Symbol ==
                _board.TileAt(2, 1).Symbol)
            {
                return _board.TileAt(2, 0).Symbol;
            }
        }

        return ' ';
    }
}