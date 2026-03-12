using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour 
{
    public static GameLogic current;
    public GameObject cardPrefab;

    [SerializeField]
    private List<CardModel> m_cards;

    private List<CardModel> m_grid;

    private CardBehaviour[] m_cardsFlipped; 

    private int m_matchesNeededToWin = 8; 
    private int m_matchesMade = 0;

    private bool m_playerCanClick = false; 

    void Awake()
    {
        if (current == null)
            current = this;
    }

	// Use this for initialization
	void Start() 
    {
        GenerateCards();
	}
	
	/// <summary>
	/// Generates a bunch of cards from all the cards we place in the array
	/// </summary>
	private void GenerateCards() 
    {
        m_cardsFlipped = new CardBehaviour[2];
        m_grid = new List<CardModel>();

        for (int i = 0; i < m_cards.Count; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                m_grid.Add(m_cards[i]);
            }
        }

        m_grid.Shuffle();

        for(int k = 0; k < m_grid.Count; k++)
        {
            GameObject card = Instantiate(cardPrefab) as GameObject;

            card.transform.SetParent(transform);

            CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();

            cardBehaviour.PopulateCard(m_grid[k]);
        }

        m_playerCanClick = true;
	}

    public void CheckCard(CardBehaviour _cardBehaviour)
    {
        if(m_cardsFlipped[0] == null)
        {
            m_cardsFlipped[0] = _cardBehaviour;
            return;
        }
        else
        {
            m_cardsFlipped[1] = _cardBehaviour;
        }

        m_playerCanClick = false;
        StartCoroutine(CompareCards());
    }

    private IEnumerator CompareCards()
    {
        yield return new WaitForSeconds(1.0f);

        if(m_cardsFlipped[0].GetCardID() == m_cardsFlipped[1].GetCardID())
        {
            m_matchesMade++;

            if(m_matchesMade == m_matchesNeededToWin)
            {
                //Debug.Log("WIN!!!!!!");
                MessageSystem.BroadcastWinScenario();
            }
        }
        else
        {
            m_cardsFlipped[0].FlipBackCard();
            m_cardsFlipped[1].FlipBackCard();
        }

        m_cardsFlipped = new CardBehaviour[2];
        m_playerCanClick = true;
    }

    public bool GetPlayerCanClick()
    {
        return m_playerCanClick;
    }
}
