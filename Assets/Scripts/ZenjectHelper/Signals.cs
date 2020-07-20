using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSignal
{
    public readonly string testText;
    public TestSignal(string text)
    {
        testText = text;
    }
}

public class CompassInitiated {}

public class GameEnded
{
    public bool won;
}