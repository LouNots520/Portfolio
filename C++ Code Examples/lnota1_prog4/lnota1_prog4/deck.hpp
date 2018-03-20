/* ------------------------------------------------------------------------- */
/* File:    deck.hpp ------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    10/30/13 ------------------------------------------------------- */
/* Header deck class ------------------------------------------------------- */
/* ------------------------------------------------------------------------- */
#include "tools.hpp"
#include "card.hpp"

class DeckT{

private:
	int max;							/* Max cards in deck */
	int n;								/* Current number of cards in deck */
	CardT** cards;						/* To dynamically store cards */

public:
	DeckT(int maximum, int current);				/* Constructor for deck */
	DeckT(int maximum);								/* Constructor for hand */
	~DeckT(){										/* Deck destructor */
		for(int x = 0; x < n; x++){
			delete cards[x];
		}
		delete[] cards;
	};
	void printD(ostream&);							/* Prints deck */
	void shuffle( );								/* Shuffle deck */
	void dealHand(DeckT* h);						/* Deal cards */
};