/* ------------------------------------------------------------------------- */
/* File:    main.cpp ------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    10/30/13 ------------------------------------------------------- */
/* Main() ------------------------------------------------------------------ */
/* ------------------------------------------------------------------------- */
#include "tools.hpp"
#include "card.hpp"
#include "deck.hpp"

using namespace std;

#define MAXD 52

int main(void){

	short int nHand;
	banner();

	srand((unsigned) time(NULL));							/* For shuffle */

	for(;;){
	cout << "\nPlease enter the number of cards to be dealt to each hand: ";
	cin >> nHand;
	if(nHand > 0 && nHand <= 26) break;
	else cout << "Invalid number entered: " << nHand;
	}

	DeckT deck(MAXD, 0);									/* Deck object */
	deck.shuffle( );
	
	DeckT hand1(nHand);										/* Hand object */
	DeckT hand2(nHand);

	deck.dealHand(&hand1);
	deck.dealHand(&hand2);

	cout << "\n-------- First Hand Cards ---------\n";
	hand1.printD(cout);

	cout << "\n\n-------- Second Hand Cards --------\n";
	hand2.printD(cout);

	cout << "\n\n----- Remaining Cards In Deck -----\n";
	deck.printD(cout);

	bye();
	return 0;
}