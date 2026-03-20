using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// Index 0 in the bool array is Left.
    /// </summary>
    public void MoveLeft()
    {
        var currentLocation = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentLocation) && _mazeMap[currentLocation][0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// Index 1 in the bool array is Right.
    /// </summary>
    public void MoveRight()
    {
        var currentLocation = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentLocation) && _mazeMap[currentLocation][1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// Index 2 in the bool array is Up.
    /// </summary>
    public void MoveUp()
    {
        var currentLocation = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentLocation) && _mazeMap[currentLocation][2])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// Index 3 in the bool array is Down.
    /// </summary>
    public void MoveDown()
    {
        var currentLocation = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentLocation) && _mazeMap[currentLocation][3])
        {
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
