using Assets.Source.Scripts.Data;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.BuildTowerPanel
{
    public class BuildTowerButton : MonoBehaviour, IPointerClickHandler, IDisposable
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _priceText;

        public delegate void PurchaseTower(TowerDataConfig config);
        public event PurchaseTower OnPurchase;

        private List<PurchaseTower> _callbacks;
        private TowerDataConfig _config;

        public BuildTowerButton Init(TowerDataConfig config)
        {
            _callbacks = new List<PurchaseTower>();
            _config = config;
            _icon.sprite = config.Icon;
            _priceText.text = $"{config.Price}";

            return this;
        }

        public BuildTowerButton AddListener(PurchaseTower callback)
        {
            OnPurchase += callback;
            _callbacks.Add(callback);
            return this;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPurchase.Invoke(_config);
        }

        public void Dispose()
        {
            foreach (var callback in _callbacks)
                OnPurchase -= callback;
        }
    }
}
