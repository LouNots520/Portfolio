/* ------------------------------------------------------------------------- */
/* File:    card.cpp ------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    10/10/13 ------------------------------------------------------- */
/* Card class -------------------------------------------------------------- */
/* ------------------------------------------------------------------------- */
#include "card.hpp"

const int points[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};
const char* suits[] = {"Unknown","Spades  ","Hearts  ","Diamonds","Clubs   "};
const char ranks[] = {"-A23456789TJQK"};

/* ------------------------------------------------------------------------- */
/* Constructor will take in two ints as parameters that will represent the - */
/* suit and rank of the card being created.--------------------------------- */
/* ------------------------------------------------------------------------- */
CardT::CardT(SuitT(s), int r){
	
	suit = SuitT(s);						/* Setting suit */
	rank = ranks[r];						/* Setting rank */

	switch(rank){							/* Setting point */
		case 'A': point = 10; break;
		case 'T': point = 10; break;
		case 'J': point = 10; break;
		case 'Q': point = 10; break;
		case 'K': point = 10; break;
		default : point = points[rank - '0'];
	}
}
/* ------------------------------------------------------------------------- */
/* Function will print out the passed card object to the console ----------- */
/* ------------------------------------------------------------------------- */
void CardT::printC(ostream& ostrm){
	ostrm << "(" << rank << " " << suits[suit] << ")";
}