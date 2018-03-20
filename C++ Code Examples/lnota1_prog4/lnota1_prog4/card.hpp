/* ------------------------------------------------------------------------- */
/* File:    card.hpp ------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    10/10/13 ------------------------------------------------------- */
/* Header card class ------------------------------------------------------- */
/* ------------------------------------------------------------------------- */
#include "tools.hpp"

#pragma once

typedef enum SuitT{UNKNOWN, SPADES, HEARTS, DIAMONDS, CLUBS};

class CardT{

private:
	SuitT suit;							/* Enumerated type for card suit */
	char rank;							/* Rank of card */
	short int point;					/* Point value of card */

public:
	CardT(SuitT(x),int r);				/* Constructor */
	~CardT() { }						/* Card destructor */
	void printC(ostream&);
};