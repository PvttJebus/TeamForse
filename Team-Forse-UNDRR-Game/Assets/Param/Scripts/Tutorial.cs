using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image displayImage;           // The UI Image component on screen
    public Sprite[] images;              // Array of images to show
    private int currentIndex = 0;        // Tracks current image index

    public Button nextButton;            // Assign in inspector
    public Button previousButton;        // Assign in inspector

    void Start()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex];
        }

        // Assign button functions
        nextButton.onClick.AddListener(ShowNextImage);
        previousButton.onClick.AddListener(ShowPreviousImage);
    }

    public void ShowNextImage()
    {
        if (images.Length == 0) return;

        currentIndex = (currentIndex + 1) % images.Length;
        displayImage.sprite = images[currentIndex];
    }

    public void ShowPreviousImage()
    {
        if (images.Length == 0) return;

        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        displayImage.sprite = images[currentIndex];
    }
}
