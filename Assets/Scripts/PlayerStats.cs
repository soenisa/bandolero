using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int health = 100;
	public int ammoPrimary = 20;
	public int ammoSecondary = 20;

    enum TypeofAmmo
    {
        Primary,
        Secondary
    };

	public void AddAmmo(int Ammotype, int amount, int modify)
    {
	    switch (Ammotype)
	    {
		    case (int)TypeofAmmo.Primary:
			    if(modify>0)
				    ammoPrimary += amount;
			    else
				    ammoPrimary = amount;
			    break;
            case (int)TypeofAmmo.Secondary:
			    if(modify>0)
				    ammoSecondary += amount;
			    else
				    ammoSecondary = amount;
			    break;
		    default:
			    Debug.Log ("wrong type");
                break;
	    }
    }

    public int GetAmmo(int Ammotype)
    {

        if (Ammotype == (int)TypeofAmmo.Primary)
	    {
		    return ammoPrimary;
	    }
        else if (Ammotype == (int)TypeofAmmo.Secondary)
        {
            return ammoSecondary;
        }
        else
        {
            Debug.Log("Wrong ammo type!");
            return 0;
        }
    }

    public int GetHealth ()
    {
	    return health;
    }

    public void AddHealth(int amount, int modify)
    {
	    if(modify>0)
		    health += amount;
	    else
		    health = amount;
    }
}
