using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableObjectOnMouseClick : MonoBehaviour
{
    public List<GameObject> objects;
    public List<string> hints;
    public GameObject hintUI;
    public GameObject waitingPrefab;
    public GameObject taskComplete;

    private int currentStep = 0;
    private Camera mainCamera;

    private bool isInteractable;

    void Start()
    {
        isInteractable = false;
        mainCamera = Camera.main;

        foreach (var obj in objects)
        {
            obj.SetActive(false); // Ensure all objects are initially disabled
        }
    }

    public void StartInteract()
    {
        EnableCurrentObject();
        SetHint();
        hintUI.SetActive(true);
        isInteractable = true;
    }

    void Update()
    {
        if (!isInteractable)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    if (hit.transform.gameObject == objects[i])
                    {
                        EnableObject(currentStep);
                        break;
                    }
                }
            }
        }
    }

    void EnableObject(int index)
    {
        if (index < objects.Count)
        {
            objects[index].SetActive(true); // Activate the current object
            DisableOutline(objects[index]);
            OnObjectEnabled();
        }
    }
    void DisableOutline(GameObject obj)
    {
        var outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
    public void OnObjectEnabled()
    {
        currentStep++;

        if (currentStep < objects.Count)
        {
            EnableCurrentObject();
            SetHint();
        }
        else if (waitingPrefab != null)
        {
            taskComplete.SetActive(true);
            waitingPrefab.SetActive(true);
            Result();
            Invoke(nameof(DisableWaitingPrefab), 2f);
        }
        else
        {
            SetHint();
        }
    }

    void EnableCurrentObject()
    {
        if (currentStep < objects.Count)
        {
            objects[currentStep].SetActive(true); // Activate the next object
        }
    }

    void SetHint()
    {
        if (!hintUI.activeSelf)
        {
            hintUI.SetActive(true);
        }
        hintUI.GetComponentInChildren<TMP_Text>().text = hints[currentStep];
    }

    private void DisableWaitingPrefab() => waitingPrefab.SetActive(false);

    public void Result()
    {
        SetHint();
        StartCoroutine(FocusOnTaskComplete());
    }

    IEnumerator FocusOnTaskComplete()
    {
        Vector3 targetPosition = taskComplete.transform.position;
        Vector3 startPosition = mainCamera.transform.position;

        float elapsedTime = 0f;
        float zoomDuration = 2f;

        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition - new Vector3(0, 0, 2f), elapsedTime / zoomDuration);
            yield return null;
        }

        mainCamera.transform.LookAt(taskComplete.transform);
    }
}