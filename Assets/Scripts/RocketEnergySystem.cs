using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class RocketEnergySystem : MonoBehaviour
{
    //float filleAmount = 1.0f;
    float plusFuel = 0.01f;
     
    public Image fuelImage;

    private void Update()
    {
        if (Rocket.instance.fuel < 0.1f)
            return;
        Rocket.instance.fuel += 0.01f;
        FuelUdate();
    }

    public void FuelUdate()
    {
        if (Rocket.instance.fuel > 0)
        {
            fuelImage.fillAmount = Rocket.instance.fuel * 0.01f;
        }
        else if(Rocket.instance.fuel <= 0)
        {
            fuelImage.fillAmount = 0;
        }
    }
}
