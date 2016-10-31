using GTA;
using System.Windows.Forms;

public class BaseScript : Script
{

    Keys tglChute;
    
    public BaseScript()
    {

        ScriptSettings config = ScriptSettings.Load(@"scripts\ToggleParachute.ini");
        tglChute = config.GetValue<Keys>("KEY", "chute_key", Keys.Space);

        KeyUp += OnKeyUp;
        Interval = 1;

    }
    
    void OnKeyUp(object sender, KeyEventArgs e)
    {

        if (e.KeyCode == tglChute)
        {

            if (Game.Player.IsAlive && Game.Player.Character.IsInAir && !Game.Player.Character.IsInWater)
            {

                if (GTA.Native.Function.Call<int>(GTA.Native.Hash.GET_PED_PARACHUTE_STATE, GTA.Game.Player.Character) == 0)
                {

                    GTA.Native.Function.Call(GTA.Native.Hash.SET_PARACHUTE_TASK_TARGET, Game.Player.Character, 2);

                }

            }

        }

    }

}