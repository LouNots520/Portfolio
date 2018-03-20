/* ------------------------------------------------------------------------- */
/* File:    deck.cpp ------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    10/30/13 ------------------------------------------------------- */
/* Deck class -------------------------------------------------------------- */
/* ------------------------------------------------------------------------- */
#include "deck.hpp"

/* ------------------------------------------------------------------------- */
/* Constructor will create a deck of maximum number of cards --------------- */
/* ------------------------------------------------------------------------- */
DeckT::DeckT(int maximum, int current){
	
	max = maximum;				/* Initializing object max to parameter */
	n = current;				/* Initializing object current to parameter */
	cards = new CardT*[max];

	for(int x = 1; x < 5; ++x){						/* Cycle through suits */
		for(int y = 1; y < 14; ++y){				/* Cycle through ranks */
			if(n == max) break;
			CardT* c = new CardT(SuitT(x), y);		/* Card Object */
			cards[n] = c;
			++n;
		}
	}
}
/* ------------------------------------------------------------------------- */
/* Constructor will create a hand object with a max cards as parameter and - */
/* current cards will start at zero ---------------------------------------- */
/* ------------------------------------------------------------------------- */
DeckT::DeckT(int maximum){
	
	max = maximum;
	n = 0;
	cards = new CardT*[max];
}
/* ------------------------------------------------------------------------- */
/* Function will print out data from DeckT object to the given stream ------ */
/* ------------------------------------------------------------------------- */
void DeckT::printD(ostream& ostrm){

	ostrm << "Cards in object: " << n << "\n\n";

	for(int x = 0; x < n; ++x){
		cards[x]->printC(ostrm);				/* Printing card */
		if((x + 1) % 6 == 0) ostrm << endl;		/* Six cards per line */
	}
}
/* ------------------------------------------------------------------------- */
/* Function will shuffle the deck object ----------------------------------- */
/* ------------------------------------------------------------------------- */
void DeckT::shuffle( ){

	for(int k = n; k > 1; --k){
		 int r = rand() % k;
		 swap(cards[r], cards[k-1]);		/* Swapping pointers of cards */
	 }
}
/* ------------------------------------------------------------------------- */
/* Function will change pointers of deck object array to hand object array - */
/* ------------------------------------------------------------------------- */
void DeckT::dealHand(DeckT* h){

	for(int k = 0; k < h->max; k++){
		h->cards[k] = cards[n - 1];
		n--;								/* Decrement cards in deck */
		(h->n)++;							/* Increment cards in hand */
	}
}