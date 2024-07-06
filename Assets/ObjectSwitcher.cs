using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objectsToSwitch;
    public Button nextButton;
    public Button previousButton;

    private int currentIndex = 0;

    void Start()
    {
        // Ensure we have objects to switch between
        if (objectsToSwitch.Length == 0)  // Corrected: 'length' to 'Length'
        {
            Debug.LogError("No objects assigned to switch between!");
            return;
        }

        // Set up button listeners
        if (nextButton != null)
            nextButton.onClick.AddListener(NextObject);
        else
            Debug.LogWarning("Next button not assigned!");

        if (previousButton != null)
            previousButton.onClick.AddListener(PreviousObject);
        else
            Debug.LogWarning("Previous button not assigned!");

        // Initialize object visibility
        UpdateObjectVisibility();
    }

    void NextObject()
    {
        currentIndex = (currentIndex + 1) % objectsToSwitch.Length;
        UpdateObjectVisibility();
    }

    void PreviousObject()
    {
        currentIndex = (currentIndex - 1 + objectsToSwitch.Length) % objectsToSwitch.Length;
        UpdateObjectVisibility();
    }

    void UpdateObjectVisibility()
    {
        for (int i = 0; i < objectsToSwitch.Length; i++)
        {
            if (objectsToSwitch[i] != null)
                objectsToSwitch[i].SetActive(i == currentIndex);
            else
                Debug.LogWarning($"Object at index {i} is null!");
        }
    }
}