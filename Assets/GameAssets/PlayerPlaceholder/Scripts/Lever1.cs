using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour, Interactable
{
    [SerializeField] private bool _isActive = false;
    [SerializeField] private string _prompt;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] public GameObject interactedLever;

    private List<Lever1> _allLevers;

    public string InteractionPrompt => _prompt;

    void Start()
    {
        _allLevers = new List<Lever1>(FindObjectsOfType<Lever1>());
        _mesh.material.color = _isActive ? Color.green : Color.red;
    }

    public bool Interact(InteractionItem interactor)
    {
        //if (!_isActive)
        //{
        //_isActive = true;
        //_mesh.material.color = Color.green;

        _allLevers.Remove(this);

            foreach (Lever1 lever in _allLevers)
            {
              
                if (lever._isActive == false)
                {
                    lever._isActive = true;
                }

                else
                {
                    lever._isActive = false;
                }

                if(lever._mesh.material.color == Color.red)
                {
                    lever._mesh.material.color = Color.green;
                }

                else
                {
                    lever._mesh.material.color = Color.red;
                }


            }

    
        //}

        return true;
    }
}

