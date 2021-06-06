using UnityEngine;
using UnityEngine.UI;
using RTS.Abstractions;
using TMPro;
using RTS.UserControlSystem.Model.ScriptableObjects;

namespace RTS.UserControlSystem
{
    public class BottomLefPresenter : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private SelectableValueModel _selectedValue;
        
        private void Start()
        {
            _selectedValue.OnChange += OnChange;
            OnChange(_selectedValue.CurrentValue);
        }
        private void OnChange(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _text.enabled = selected != null;

            if (selected != null)
            {
                _selectedImage.sprite = selected.Icon;
                _text.text = $"{selected.Health}/{selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var color = Color.Lerp(Color.red, Color.green, selected.Health / (float)selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
    }
}
