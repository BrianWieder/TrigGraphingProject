using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConstantSlider : MonoBehaviour {

    [SerializeField]
    private Text descriptionTextBox;

    [SerializeField]
    private string descriptionText;

    private void Start()
    {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { OnMouseEnter(); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((eventData) => { OnMouseExit(); });
        trigger.triggers.Add(entry2);
    }

    public void OnMouseEnter()
    {
        print("Enter");
        descriptionTextBox.text = descriptionText;
    }

    public void OnMouseExit()
    {
        descriptionTextBox.text = "";
    }


}
