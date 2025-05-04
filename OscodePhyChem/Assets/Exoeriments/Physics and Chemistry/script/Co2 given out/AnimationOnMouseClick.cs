using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class AnimationOnMouseClick : MonoBehaviour
{
    public Animator animator;

    public List<GameObject> objects;
    public List<string> Hints;
    public GameObject _hint;
    public GameObject _waitingPrefab;
    public GameObject _taskComplete;
    [SerializeField] private List<string> animationTriggers;

    private int currentStep = 0;
    private Camera mainCamera;
    public float zoomSpeed = 2f; 
    public float zoomDuration = 2f;

    private bool _isInteractable;
    void Start()
    {
        _isInteractable = false;
        mainCamera = Camera.main;
        foreach (var obj in objects)
        {
            DisableOutline(obj);
        }
    }
    public void StartInteract()
    {
        EnableOutline(objects[currentStep]);
        SetHint(); 
        _hint.SetActive(true);
        _isInteractable = true;
    }
    void Update()
    {
        if(!_isInteractable)
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
                        PlayAnimation(currentStep);
                        break; 
                    }
                }
            }
        }
    }

    void PlayAnimation(int index)
    {
        Debug.Log("current step = "+index +"objects = "+objects.Count);
        if (index < objects.Count)
        {
            animator.SetTrigger(animationTriggers[index]); 
            DisableOutline(objects[currentStep]);
        }
    }
    public void OnAnimationComplete()
    {
        Debug.Log("Animation Completed");
        currentStep++;

        if (currentStep < objects.Count)
        {
            EnableOutline(objects[currentStep]);
            SetHint();
        }
        else if(_waitingPrefab!=null)
        {
            _taskComplete.SetActive(true);
            _waitingPrefab.SetActive(true);
            Result();
            Invoke(nameof(DisableWaitingPrefab), 2f);

        }
        else
        {
            SetHint();
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

    void EnableOutline(GameObject obj)
    {
        var outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = true;
        }
    }
    void SetHint()
    {
        if (!_hint.activeSelf)
        {
            _hint.SetActive(true);
        }
        _hint.GetComponentInChildren<TMP_Text>().text= Hints[currentStep];
    }
    private void DisableWaitingPrefab() => _waitingPrefab.SetActive(false); 
    public void Result()
    {
        SetHint();
        StartCoroutine(FocusOnTaskComplete());
    }

    IEnumerator FocusOnTaskComplete()
    {
        Vector3 targetPosition = _taskComplete.transform.position;
        Vector3 startPosition = mainCamera.transform.position;

        float elapsedTime = 0f;

        Vector3 direction = (targetPosition - startPosition).normalized;

        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition - direction * 2f, elapsedTime / zoomDuration);
            yield return null;
        }

        mainCamera.transform.LookAt(_taskComplete.transform);
    }
}
