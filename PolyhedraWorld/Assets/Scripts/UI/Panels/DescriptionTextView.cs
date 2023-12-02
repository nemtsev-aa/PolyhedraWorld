using TMPro;
using UnityEngine;

public class DescriptionTextView : UICompanent {
    [SerializeField] private TextMeshProUGUI _descriptionText;

    public void Init(string text) {
        _descriptionText.text = text;
    }
}
