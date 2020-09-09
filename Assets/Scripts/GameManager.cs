using System.Collections;
using System.Collections.Generic;
using UnityEngine.iOS;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
        public static GameManager Instance;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }
    #endregion
    
    public MovePlayer movePlayer;
    public bool isDragging = false;
    Touch touch;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetMouseButtonDown(0) || (touch.phase == TouchPhase.Began))
            {
                isDragging = true;
                OnDragStart();
            }

            if(Input.GetMouseButtonUp(0) || (touch.phase == TouchPhase.Ended))
            {
                isDragging = false;
                OnDragEnd();
            }

            if(isDragging)
            {
                OnDrag();
            }
        }
        
    }

    private void OnDragStart()
    {
    }

    private void OnDrag()
    {
        movePlayer.MoveForv();
    }

    private void OnDragEnd()
    {
    }
}
