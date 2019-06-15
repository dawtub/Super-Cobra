using UnityEngine;

public class Fuel : MonoBehaviour
{
    public static double FuelLevel = 100;
    public ProgressBar pb;

    // Start is called before the first frame update
    void Start()
    {
        pb.BarValue = (int)FuelLevel;
    }

    // Update is called once per frame
    void Update()
    {
        pb.BarValue = (int)FuelLevel;
    }

    public static void ResetFuelLevel()
    {
        FuelLevel = 100;
    }

    public static void Refuel()
    {
        if (FuelLevel >= 50)
        {
            ResetFuelLevel();
        } else
        {
            FuelLevel += 50;
        }
    }
}
