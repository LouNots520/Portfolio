/* ------------------------------------------------------------------------- */
/* File:    main.c --------------------------------------------------------- */
/* Author:  Louis Notarino ------------------------------------------------- */
/* Date:    12/05/13 ------------------------------------------------------- */
/* Main() ------------------------------------------------------------------ */
/* ------------------------------------------------------------------------- */
#include "tools.h"

#define FILEIN "lucky.txt"
#define NUM 50

void read(int lucky[NUM], stream instream);
int start( );
int binSearch(int lucky[], int first, int last, int key);
void award(char* prizes[10], int* prizeCountp);

int main(void){

	int lucky[NUM], key, x, used[10];
	stream instream;
	char again = '\0';
	int prizeCount = 10;
	int* prizeCountp = &prizeCount;
	char* prizes[10] = {"a half eaten cookie", "22 cents", "an Xbox One",
						"$1,000", "a high five", "a double A battery",
						"new car", "trip for two to Hawaii", "a sandwich",
						"an iPhone 5s"};

	banner();
	srand((unsigned) time(NULL));

	instream = fopen(FILEIN, "r");
	if(!instream) fatal("Cannot open %s for reading!", FILEIN);
	read(lucky, instream);
	fclose(instream);

	for(x = 9; x >= 0; --x) used[x] = 1000;					 /* For used IDs */

	for(;;){
		key = start( );
		if(binSearch(used, 0, 9, key) >= 0)
			printf("Entered ID is an already winning ID!\n");
		else if(binSearch(lucky, 0, NUM - 1, key) >= 0){  /* Found unused ID */
			award(prizes, &prizeCount);
			if(x < 9) used[++x] = key;
		}
		else printf("Sorry! No match found for ID: %i\n", key);
		printf("\nEnter another ID? (Y/N): ");
		while(again != '\n') scanf("%c", &again);	   /* Leading whitespace */
		scanf("%c", &again);
		again = toupper(again);
		if(again == 'N') break;
	}
	bye();

	return 0;
}
/* ------------------------------------------------------------------------- */
/* Function will read in numbers from text file ---------------------------- */
/* ------------------------------------------------------------------------- */
void read(int lucky[], stream instream){

	int x = 0;
	for(;;){
		fscanf(instream, "%i", &lucky[x]);
		if(feof(instream)) break;				/* End of file check */
		++x;
	}
}
/* ------------------------------------------------------------------------- */
/* Function will prompt the user for input and return it ------------------- */
/* ------------------------------------------------------------------------- */
int start( ){
	
	cstring input;
	int x;
	
	printf("\n\nGreetings! Ready to test how lucky you are?");
	printf("\n\nPlease enter the last three digits in your student ID: ");
	scanf("%s", &input);
	x = atoi(&input);
	return x;
}
/* ------------------------------------------------------------------------- */
/* Function will search for key in array and returns subscript of found key  */
/* ------------------------------------------------------------------------- */
int binSearch(int lucky[], int first, int last, int key){

	int mid;

	if (last < first) return -1;
	mid = first + (last - first) / 2;
	if (lucky[mid] == key) return mid;
	if (lucky[mid] > key) return binSearch(lucky, first, mid - 1, key);
	return binSearch(lucky, mid + 1, last, key );
}
/* ------------------------------------------------------------------------- */
/* Function will check if there are any prizes remaining and award a random  */
/* prize remaining (if any) ------------------------------------------------ */
/* ------------------------------------------------------------------------- */
void award(char* prizes[10], int* prizeCountp){

	int r;
	cstring p;											/* Prize string */

	if(*prizeCountp > 0){
		r = rand() % *prizeCountp;
		p = prizes[r];									/* Unused Prize */
		prizes[r] = prizes[*prizeCountp - 1];
		prizes[*prizeCountp - 1] = p;					/* Swap to end */
		printf("Congratulations! You've won %s!\n", p);
		--*prizeCountp;									/* Update prize count */
	}
	else puts("No more remaining prizes.\nBe sure to try again next week!");
}