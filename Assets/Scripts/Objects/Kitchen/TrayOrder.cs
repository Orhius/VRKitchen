using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrayOrder : MonoBehaviour
{
    [SerializeField] private List<SocketTagInteractor> sockets = new();

    public List<FoodData> foodData { get; private set; } = new();
    public List<GameObject> foodObjects { get; private set; } = new();

    private void OnEnable()
    {
        foreach (var socket in sockets)
        {
            socket.selectEntered.AddListener(SelectEntered);
            socket.selectExited.AddListener(SelectExited);
        }
    }
    private void OnDisable()
    {
        foreach (var socket in sockets)
        {
            socket.selectEntered.RemoveListener(SelectEntered);
            socket.selectExited.RemoveListener(SelectExited);
        }
    }
    private void SelectEntered(SelectEnterEventArgs args)
    {
        GameObject attachedObject = args.interactableObject.transform.gameObject;
        foodData.Add(attachedObject.GetComponent<Food>().foodData);
        foodObjects.Add(attachedObject);
    }
    private void SelectExited(SelectExitEventArgs args)
    {
        GameObject detachedObject = args.interactableObject.transform.gameObject;
        foodData.Remove(detachedObject.GetComponent<Food>().foodData);
        //foodObjects.Remove(detachedObject);
    }
    public void ClearTray()
    {
        foreach (var obj in foodObjects)
        {
            Destroy(obj.gameObject);
        }
        foodData.Clear();
        foodObjects.Clear();
    }
}
