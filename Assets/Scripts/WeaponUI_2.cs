using UnityEngine;
using UnityEngine.UI;

public class WeaponImageManager : MonoBehaviour
{
    public Image[] weaponImages; // Assign your four images to these slots in the inspector
    public WeaponType weaponTypeScript;

    public float transitionSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //weaponTypeScript = GetComponent<WeaponType>();
        UpdateWeaponImages();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeaponImages();
    }

    private void UpdateWeaponImages()
    {
        for (int i = 0; i < weaponImages.Length; i++)
        {
            float targetX = (i == weaponTypeScript.chosenWeaponID) ? -880f : -1040f;
            Vector2 targetPosition = new Vector2(targetX, weaponImages[i].rectTransform.anchoredPosition.y);

            MoveImage(weaponImages[i], targetPosition);
        }
    }

    private void MoveImage(Image image, Vector2 targetPosition)
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        Vector2 currentPosition = rectTransform.anchoredPosition;

        // Interpolate between current position and target position
        Vector2 newPosition = Vector2.Lerp(currentPosition, targetPosition, Time.deltaTime * transitionSpeed);
        rectTransform.anchoredPosition = newPosition;
    }
}
