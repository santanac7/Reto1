using UnityEngine;
using UnityEngine.EventSystems;

public class SoundButtons : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter (PointerEventData eventData){
        AudioManager.intance.PlaySfx(4);
    }
}