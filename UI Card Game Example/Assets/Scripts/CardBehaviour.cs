using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour 
{
    private CardModel m_cardModel;
    private Image m_cardImage;
    private Button m_button;

	// Use this for initialization
	void OnEnable () 
    {
       // m_cardModel = new CardModel();
        m_cardImage = GetComponent<Image>();
        m_button = GetComponent<Button>();
	}

    public void PopulateCard(CardModel _model)
    {
        m_cardModel = _model;

        m_cardImage.sprite = m_cardModel.cardBack;
    }
	
    public void FlipCard()
    {
        if (!GameLogic.current.GetPlayerCanClick())
            return;

        m_cardImage.sprite = m_cardModel.cardSprite;
        m_button.interactable = false;

        GameLogic.current.CheckCard(this);
    }

    public void FlipBackCard()
    {
        m_cardImage.sprite = m_cardModel.cardBack;
        m_button.interactable = true;
    }

    public int GetCardID()
    {
        return m_cardModel.id;
    }
}
