using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using NUnit.Framework;
public class AssertEx
{
    public static void AreEqualVec2(Vector2 exp, Vector2 act,float delta=1e-6f)
    {
        if (AreNotEqual(exp.x, act.x, delta) || AreNotEqual(exp.y, act.y, delta))
            throw new AssertionException($"except ({exp.x},{exp.y}) but was ({act.x},{act.y})");
    }

    private static bool AreNotEqual(float expx, float actx, float delta)
    {
        return expx > actx + delta || expx < actx - delta;
    }
}
