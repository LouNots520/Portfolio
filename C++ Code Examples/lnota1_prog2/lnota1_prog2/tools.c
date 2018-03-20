/* File: tools.c - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  /
/  The tools library.                                                           /
/  Assorted utility routines for use in C programs.                             /
/  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
#include "tools.h"

/* ---------------------------------------------------------------------------- /
/  Portability code.                                                            /
/ ---------------------------------------------------------------------------- */
#ifdef UNIX
	void clearscreen( void ) {   fprintf( stderr, "\f" );  }                                                          
	/* ---------------------------------------------------------------------------
	**  Print termination message. 
	*/
	void bye( void ) { fputs( "\nNormal termination.\n", stderr ); }                                                      
#endif

#ifdef VISUAL
	void clearscreen( void ) {  }                                                          
	/* ---------------------------------------------------------------------------
	**  Print termination message. 
	*/
	void bye( void ) { fputs( "\nNormal termination.\n", stderr ); }                                                      
#endif

#ifdef BORLAND
	#include <conio.h>        
	void clearscreen( void ) {   clrscr();  }                                                          
	/* ---------------------------------------------------------------------------
	**  Print termination message and wait for the user to type "." and hit ENTER. 
	*/
	void 
	bye( void )                                    
	{   
		fprintf( stderr, "\nNormal termination." );
		hold();   
	}                                                      
#endif

/* ---------------------------------------------------------------------------- /
/  Routine screen and process management.                                       /
/ ---------------------------------------------------------------------------- */

/* ---------------------------------------------------------------------------  
** Print a neat header on the output.                                        
*/
void    
banner( void ){ fbanner( stdout ); } 

/* -------------------------------------------------------------------------- */
void 
fbanner( stream sout )
{   char date[16], time[9];

	when(date, time);
	clearscreen();
	fprintf( sout, "\n-------------------------------------------------------\n" );
	fprintf( sout, "\t%s \n\t%s \n\t%s  %s\n", NAME, CLASS, date, time );
	fprintf( sout,   "-------------------------------------------------------\n" );
}

/* --------------------------------------------------------------------------
** This is a handy function for messages of all sorts.  
**  It formats, prints, and rings the bell.                   
**  It accepts a format followed by a variable number of data items to print.
*/
void
say (string format, ...)
{   va_list vargs;                               /* optional arguments */

	va_start( vargs, format );
	vfprintf( stderr, format, vargs );
	fprintf( stderr, "\a\a\n" );
}

/* --------------------------------------------------------------------------
** Delay progress of program for some number of seconds using a "busy wait".   
*/
void 
delay( int secs )
{   time_t goal;

	goal = time( NULL ) + secs;  
	do  { /* Nothing */  } while (time(NULL) < goal);    
}

/* --------------------------------------------------------------------------
 ** Delay progress for some number of milliseconds using Unix blocking.   
 */
//void 
//mdelay( int millisecs ) {  usleep( 1000*millisecs ); }

/* --------------------------------------------------------------------------
**  Print message and wait for the user to type a newline.                     
*/
void 
hold( void )                                    
{   
	fputs( "\n\n\aPress '.' and 'Enter' to continue", stderr );
	while ( getchar() != '.' )  				/* tight loop */ ;    
}                                                      

/* ----------------------------------------------------------------------------/
/  Error handling and error recovery functions.                                /
/-----------------------------------------------------------------------------*/

/* ---------------------------------------------------------------------------- 
** This function is for error messages.  
**    It takes a format argument followed by any number of data arguments.
**    It formats and prints an error message, then exits.                            **
*/
int
fatal (string format, ...)
{   va_list vargs;                               /* optional arguments */

	va_start(vargs, format);
	vfprintf(stderr, format, vargs);
	fprintf(stderr, "\a\a\n");
	hold();
	return (1);
}

/* ----------------------------------------------------------------------------
**  Clean out the rest of the current line, discarding all characters up to and
**   including the newline character. Use after an input error to prepare for 
**   resumption of numeric input.                                              
*/
void 
cleanline ( stream sin )                                    
{   char ch;                      /* Character currently under input scanner. */

	do { 
		ch = fgetc(sin);           			/* Read next character */
	} while ( !feof( sin ) && ch != '\n' );	/* Quit at first newline */
}                                                      

/* ----------------------------------------------------------------------------
**  Clean out the rest of the current line up to and including the newline 
**   character. Write the characters to an error log file.  Use after an 
**   input error to prepare for resumption of numeric input.                                              
*/
void 	
clean_and_log( stream sin, stream sout ) 
{   char ch;                      /* Character currently under input scanner. */

	do { 
		ch = fgetc(sin);           			/* Read next character */
		fputc(ch, sout); 					/* Echo to error stream */ 
	} while ( !feof( sin ) && ch != '\n' );	/* Quit at first newline */
}                                                      

/* ---------------------------------------------------------------------------- /
/  Routines for handling the time and date.                                     /
/ ---------------------------------------------------------------------------- */

/* ----------------------------------------------------------------------------
** Store the current date and time in the arguments.  
**      System's date format is: "Fri Jun  9 10:15:55 1995\n"  
**      After extraction, date is: "Fri Jun  9 1995"    hour is: "10:15:55" 
*/
void 
when( char date[], char hour[] )
{   
	time_t now;          /* Stores an integer encoding of the date and time. */ 
	string nowstring;    /* Stores the date and time in a readable form.     */

	now = time(NULL);              /* Get the date and time from the system. */
	nowstring = ctime(&now);                   /* Convert to string form.    */
	strncpy( date, nowstring, 10);             /* Extract day, month, date.  */
	strncpy( &date[10], &nowstring[19], 5);    /* Extract space and year.    */
	date[15]  = '\0';                          /* Add the string terminator. */       
	strncpy( hour, &nowstring[11], 8);         /* Copy hour:minutes:seconds. */
	hour[8]  = '\0';                           /* Add the string terminator. */
}

/* --------------------------------------------------------------------------
** Store the current date in the argument and return a pointer to it. 
**      date format is: "Fri Jun  9 1995"                                    
*/
string  
today( char date[] )
{   
	time_t now;          /* Stores an integer encoding of the date and time. */ 
	string nowstring;    /* Stores the date and time in a readable form.     */

	now = time(NULL);              /* Get the date and time from the system. */
	nowstring = ctime(&now);                   /* Convert to string form.    */
	strncpy( date, nowstring, 10);             /* Extract day, month, date.  */
	strncpy( &date[10], &nowstring[19], 5);    /* Extract space and year.    */
	date[15]  = '\0';                          /* Add the string terminator. */       
	return( date );  
}

/* --------------------------------------------------------------------------
** Store the current time in hour and return a pointer to it.   
**      hour format is: "10:15:55"                                           
*/
string 
oclock( char hour[] )
{   
	time_t now;          /* Stores an integer encoding of the date and time. */ 
	string nowstring;    /* Stores the date and time in a readable form.     */

	now = time(NULL);              /* Get the date and time from the system. */
	nowstring = ctime(&now);              /* Convert to string form.         */
	strncpy( hour, &nowstring[11], 8);    /* Extract hour, minutes, seconds. */
	hour[8]  = '\0';                      /* Add the string terminator.      */
	return( hour );  
}

/* ---------------------------------------------------------------------------- /
/  Miscellaneous: menu handling and random selection.                           /
/  ----------------------------------------------------------------------------*/

/* ------------------------------------------------------------------------------
** Display a menu then read an alphabetic menu choice character.               
*/
char 
menu_c (string title, int n, const string menu[])                                                      
{   int k;
	char ch;
	
	printf("\n%s\n\n", title); 
	for( k=0; k<n; ++k ) printf("\t%s \n", menu[k]);     
	printf("\nEnter code of desired item: ");    
	scanf(" %c", &ch);                             /* Skip leading whitespace. */
	cleanline(stdin);                              /* Flush input line buffer. */
	return ch;
}

/* ------------------------------------------------------------------------------
** Display a menu then read and validate a numeric menu choice.                
*/
int 
menu_i (string title, int n, const string menu[])                                                      
{
	int ok, k, choice;

	printf("\n%s\n", title); 
	for(;;) {   
		for( k=0; k<n; ++k ) printf("\t %d. %s \n", k, menu[k]);        
		printf("\nEnter number of desired item: ");    
		ok = scanf("%d", &choice);  
		if (ok==1 && 0 <= choice && choice < n) break;
		cleanline(stdin);
		puts("Illegal choice or input error; try again.");
	}
	return choice;
}                                                                    

/* ---------------------------------------------------------------------------- 
** Return a random integer uniformly distributed between 0 and range-1.
**   Uses the system function "rand()".                                
**   Seed must be initialized before use by calling srand().                                
**   Divide possible numbers into blocks of size=range.             
**   Discard the leftovers on the "tail end" of the representable number line.
**   Result is remainder when an acceptable random number is divided by range.   
*/
int 
evenly( int range )
{
	int num;            /* Random value we generate.                     */
	int limit;      	/* Largest representable even multiple of range. */        
	
	limit = RAND_MAX - RAND_MAX % range;
	do { num = rand(); }   		            /* Keep rolling the dice... */        
	while (num >= limit);		/* until you get a num less than limit. */ 
	return num % range;			          /* Scale num to target range. */	
}

/* ---------------------------------------------------------------------------- 
** Return a random double uniformly distributed between 0 and 1.
**   Uses the system function "rand()".                                
**   Seed must be initialized before use by calling srand().                                
*/
double randy () { return  rand() / (double)INT_MAX; }

/* ---------------------------------------------------------------------------- 
** Round a double to the nearest integer. 
int round( double d )
{  
	if (d >= 0.0) return (int)(d + 0.5); 
	else          return (int)floor(d + 0.5); 
} 
*/