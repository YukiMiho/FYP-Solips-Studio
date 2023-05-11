//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Button3 : MonoBehaviour, Interactable
//{

//    [SerializeField] public MeshRenderer mesh;

//    [SerializeField] private string _prompt;

//    private bool isActivated = false;

//    public string InteractionPrompt => _prompt;
////    public bool Interact(InteractionItem interactor)
////    {
////        Debug.Log(message: "Button activated!");
////    //    if (!isActivated)
////    //    {
////    //        isActivated = true;
////    //        ActivateOtherLevers(interactor);
////    //    }

////    //    Debug.Log(message: "Lever activated!");
////    //    return true;
////    //}

////    //private void ActivateOtherLevers(InteractionItem activatedButton)
////    //{
////    //    Button3[] allLevers = FindObjectsOfType<Button3>();

////    //    foreach (Button3 button in allButtons)
////    //    {
////    //        if (button != activatedButton.GetComponent<Button3>())
////    //        {
////    //            button.isActivated = false;
////    //            button.mesh.material.color = Color.green;
////    //        }
////    //        else
////    //        {
////    //            activatedButton.GetComponent<Button3>().mesh.material.color = Color.red;
////    //        }
////    //    }
////    //}

////    void Start()
////    {
////        MeshRenderer mesh = GetComponent<MeshRenderer>();
////        mesh.material.color = Color.green;
////    }
//}   