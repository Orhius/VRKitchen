using UnityEngine;

public class OrderTrigger : MonoBehaviour
{
    [SerializeField] private string orderTag = "Tray";

    private TrayOrder tray;

    private void OnEnable() => EventBus.OnOrderIsComplete += ClearCurrentTray;
    private void OnDisable() => EventBus.OnOrderIsComplete -= ClearCurrentTray;

    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == orderTag)
        {
            tray = col.gameObject.GetComponent<TrayOrder>();
            EventBus.OrderInTrigger(tray.foodData);
        }
    }
    private void ClearCurrentTray(string id)
    {
        if(tray == null) { return; }
        tray.ClearTray();
        tray = null;
    }
}
