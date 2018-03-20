/* ------------------------------------------------------------------------- */
/* This program will read exam scores and student names from a text file. -- */
/* The program will then echo out the input, compute and display the max --- */
/* score and average score, followed by the students that got that score. -- */
/* ------------------------------------------------------------------------- */
#include <stdio.h>
#include "tools.h"

void echo(float scores[], char names[23][16], int x);
void maxAvg(float scores[], float* maxp, float* avg, int x);
void output(float scores[], char names[23][16], float* maxp,
			float* avgp, int x);

int main (void){

	#define FILEIN "exams.txt"

	float scores[23];			/* Exam Scores */
	char names[23][16];			/* Names */
	stream instream;
	int x = 0;					/* Used as count */
	float max = 0;
	float avg = 0;
	float* maxp = &max;			/* Pointer to max value */
	float* avgp = &avg;			/* Pointer to avg value */


	banner();
	instream = fopen (FILEIN, "r");
	if(!instream) fatal("Cannot open %s for reading!", FILEIN);

	for(;;){
		fscanf(instream,"%f %15[^\n]", &scores[x], names[x]);
		if(feof(instream)) break;
		if(scores[x] > 100 || scores[x] < 0){
			fatal("Invalid score read: %.1f", scores[x]);
		}
		++x;
	}
	if(x == 0) fatal("File %s is empty!", FILEIN);
	fclose(instream);
	echo( scores, names, x);
	maxAvg(scores, &max, &avg, x);
	output(scores, names, &max, &avg, x);
	bye();

	return 0;
}
/* ------------------------------------------------------------------------- */
/* Function will echo out the input. --------------------------------------- */
/* ------------------------------------------------------------------------- */
void echo(float scores[], char names[23][16], int x){

	int y;

	puts("\n---- Exam Scores ----");
	for( y = 0; y < x ; ++y){
		printf("%-6.1f%s\n", scores[y], names[y]);
	}
}
/* ------------------------------------------------------------------------- */
/* Function will compute the max and average score. ------------------------ */
/* ------------------------------------------------------------------------- */
void maxAvg(float scores[], float* maxp, float* avgp, int x){

	int y;

	for( y = 0; y < x ; ++y){
		*avgp += scores[y];
		if(scores[y] > *maxp) *maxp = scores[y];
	}
	*avgp = *avgp / x;
}
/* ------------------------------------------------------------------------- */
/* Function will output the average and max score, along with the name of -- */
/* students that scored the max. ------------------------------------------- */
/* ------------------------------------------------------------------------- */
void output(float scores[], char names[23][16], float* maxp,
			float* avgp, int x){

	int y;

	printf("\nAverage Score: %.1f\n", *avgp);
	printf("\nStudents who scored the max score of %.1f:\n", *maxp);
	for( y = 0; y < x ; ++y){
		if(scores[y] == *maxp) printf("%s\n", names[y]);
	}
}