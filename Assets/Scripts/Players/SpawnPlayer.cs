using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private MovePlayer _movePlayer;
    private Vector3 _downPos;
    [SerializeField] private float _priceUnit;
    private void Awake()
    {
        _camera = Camera.main;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                _downPos = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (_downPos == hit.point && Energy.instance.BuyUnit(_priceUnit)) 
                { 
                    Instantiate(_movePlayer, hit.point, Quaternion.identity); 
                }
            }
        }
    }
}
