using TMPro;
using UnityEngine;

public class TrashbinClear : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI remainText;

    public void UpdateText(ItemConfig items)
    {
        remainText.text = $"Remain trash: {items.itemsInLevel - items.itemsCleared} \n\n Press E to take out the trash";
    }

    public void ClearText()
    {
        remainText.text = "";
    }
}
