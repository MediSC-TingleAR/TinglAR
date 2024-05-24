using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MainGame
{
    public class MainGameManager : MonoBehaviour
    {
        [SerializeField] private MainGameUI _mainGameUI;
        [Header("Canvases")]
        [SerializeField] private GameObject _niceWorkCanvas;
        [SerializeField] private GameObject _finishGameCanvas;
        [SerializeField] private GameObject _finishPanel;

        [Header("GameModules")]
        [SerializeField] private InjectionCheck _injectionCheck;
        [SerializeField] private SplashAttack _splashAttack;
        [SerializeField] private Boss _boss;
        [SerializeField] private GameObject _enemyModule;

        [Space(10)]
        [SerializeField] private TMP_Text _killCount;

        public int KillCount { get; private set; }


        void Start()
        {
            _injectionCheck.onInjected += OnFinishInjection;
            _splashAttack.onKillEnemy += SetKillCount;
            _boss.onKilled += onKillBoss;
        }

        public void OnFinishInjection()
        {
            _niceWorkCanvas.gameObject.SetActive(true);
        }

        public void OnClickKillGerms()
        {
            _injectionCheck.transform.parent.gameObject.SetActive(false);
            _niceWorkCanvas.gameObject.SetActive(false);
            _finishGameCanvas.gameObject.SetActive(true);
            _finishPanel.gameObject.SetActive(false);
            _splashAttack.gameObject.SetActive(true);
            _enemyModule.gameObject.SetActive(true);
        }

        public void OnFinishKillGerms()
        {
            _boss.IsWakeUp = true;
        }

        private void onKillBoss()
        {
            Debug.Log("Boss Killed");
        }

        private void SetKillCount(int count)
        {
            KillCount += count;
            _killCount.text = $"KILL COUNT : {KillCount}";
            if (KillCount >= 5)
                OnFinishKillGerms();
        }
    }

}
