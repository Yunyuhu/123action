using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.UI;

public class ARClothingManager : MonoBehaviour
{
    public ARHumanBodyManager bodyManager;
    public List<GameObject> clothingOptions;
    public Button nextButton;
    public Button previousButton;

    private GameObject currentBodyInstance;
    private int currentClothingIndex = 0;

    void Start()
    {
        if (bodyManager == null)
        {
            bodyManager = FindObjectOfType<ARHumanBodyManager>();
        }

        bodyManager.humanBodiesChanged += OnHumanBodiesChanged;

        // Set up buttons
        if (nextButton != null)
            nextButton.onClick.AddListener(NextClothing);
        if (previousButton != null)
            previousButton.onClick.AddListener(PreviousClothing);
    }

    void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
    {
        if (eventArgs.added.Count > 0)
        {
            currentBodyInstance = eventArgs.added[0].gameObject;
            UpdateClothing();
        }
    }

    public void NextClothing()
    {
        currentClothingIndex = (currentClothingIndex + 1) % clothingOptions.Count;
        UpdateClothing();
    }

    public void PreviousClothing()
    {
        currentClothingIndex = (currentClothingIndex - 1 + clothingOptions.Count) % clothingOptions.Count;
        UpdateClothing();
    }

    void UpdateClothing()
    {
        if (currentBodyInstance != null)
        {
            // Deactivate all clothing options
            foreach (var option in clothingOptions)
            {
                if (option != null)
                {
                    var clothingInstance = currentBodyInstance.transform.Find(option.name);
                    if (clothingInstance != null)
                    {
                        clothingInstance.gameObject.SetActive(false);
                    }
                }
            }

            // Activate the selected clothing option
            if (clothingOptions[currentClothingIndex] != null)
            {
                var selectedClothingInstance = currentBodyInstance.transform.Find(clothingOptions[currentClothingIndex].name);
                if (selectedClothingInstance != null)
                {
                    selectedClothingInstance.gameObject.SetActive(true);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (bodyManager != null)
        {
            bodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
        }
    }
}