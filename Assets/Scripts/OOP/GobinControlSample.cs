using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobinControlSample : EnemyControlSample
{
    // Start is called before the first frame update
    public override void Setup(int hp)
    {
        base.Setup(hp);
        Debug.LogError("and Goblin");
    }
}
