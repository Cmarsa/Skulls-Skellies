using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public GameObject[] weaponImages;
    public WeaponType weaponType;
    private Vector3 defaultPosition;
    private Vector3 equipedPosition;
    private Vector3 unequipedPosition;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SwitchImage());
    }

    IEnumerator SwitchImage()
    {
        for(int i = 0; i < weaponImages.Length; i++)
        {
            defaultPosition =  new Vector3(weaponImages[i].transform.localPosition.x, weaponImages[i].transform.localPosition.y, 0);
            unequipedPosition =  new Vector3(-1040.0f, weaponImages[i].transform.localPosition.y, 0);
            equipedPosition =  new Vector3(-880.0f, weaponImages[i].transform.localPosition.y, 0);
            RectTransform currentPosition = weaponImages[i].GetComponent<RectTransform>();
            
            Vector3 currentLocation = new(defaultPosition.x, defaultPosition.y, defaultPosition.z);
            Vector3 equipedTargetPos = new(equipedPosition.x, equipedPosition.y, equipedPosition.z);
            Vector3 unequipedTargetPos = new(unequipedPosition.x, unequipedPosition.y, unequipedPosition.z);

            currentPosition.localPosition = currentLocation;

            if(i == weaponType.chosenWeaponID)
            {
                while(currentLocation.x < equipedTargetPos.x)
                {
                    currentLocation.x = currentLocation.x + 1 * Time.deltaTime * 200;

                    currentPosition.localPosition = currentLocation;
                    yield return i++;
                }
            }
            else
            {
                while(currentLocation.x > unequipedTargetPos.x)
                {
                    currentLocation.x = currentLocation.x - 1 * Time.deltaTime * 400;

                    currentPosition.localPosition = currentLocation;
                    yield return i++;
                }
            }
        }
    }
}
