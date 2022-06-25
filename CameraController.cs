using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivityMouse = 200f;
    private float _mouseX;
    private float _mouseY;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivityMouse * Time.deltaTime;
        _player.Rotate(_mouseX * new Vector3(0f, 1f, 0f));
        transform.Rotate(-_mouseY * new Vector3(1f, 0f, 0f));
    }
}
