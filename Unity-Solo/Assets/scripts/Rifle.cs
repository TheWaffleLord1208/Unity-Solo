using UnityEngine;

public class Rifle : Weapon
{
    public void changeFireMode()
    {
        if (fireModes >= 2)
        {
            currentFireMode++;

            if (currentFireMode >= 2)
                currentFireMode = 0;

            if (currentFireMode == 0)
            {
                holdToAttack = false;
                rof = 1;
            }
            else if (currentFireMode == 1)
            {
                holdToAttack = true;
                rof = .25f;
            }
        }
    }
}