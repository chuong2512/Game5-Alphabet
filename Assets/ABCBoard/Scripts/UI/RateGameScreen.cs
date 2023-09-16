﻿using System;
using BabySound.Scripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ABCBoard.Scripts.UI
{
    public class RateGameScreen : AppPopup
    {
        [SerializeField] private Button _rateButton;

        public override ScreenType GetID() => ScreenType.RateGame;

        public override void OnOpen()
        {
            transform.DOKill();
            transform.GetComponent<RectTransform>().DOAnchorPosY(-1500, 0).OnComplete(() =>
            {
                transform.GetComponent<RectTransform>().DOAnchorPosY(55, 0.5f);
            });
        }

        private void Start()
        {
            _rateButton.onClick.AddListener(RateGame);
        }

        private void RateGame()
        {
#if UNITY_ANDROID
            Application.OpenURL(string.Format("market://details?id=" + Application.identifier));
#elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/" + Application.identifier);
#endif
            GameDataManager.Instance.playerData.Rated();
            Back();
        }
    }
}