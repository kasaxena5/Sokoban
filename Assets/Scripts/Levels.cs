using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Levels
{
    public static char[,] loadedLevel;
    public readonly static int n = 9;
    public readonly static char[,] level1 = {
        { '@','@','@','@','@','.','.','.','.' },
        { '@','.','.','.','@','.','.','.','.' },
        { '@','.','#','.','@','.','@','@','@' },
        { '@','.','#','.','@','.','@','.','@' },
        { '@','@','@','.','@','@','@','.','@' },
        { '.','@','@','.','.','.','.','.','@' },
        { '.','@','.','.','#','@','.','.','@' },
        { '.','@','.','P','.','@','@','@','@' },
        { '.','@','@','@','@','@','.','.','.' },
    };
}
