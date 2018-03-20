/* file: tools.h ------------------------------------------------------------- */
/* header file for the tools library.                                          */
/* --------------------------------------------------------------------------- */
/* Local definitions and portability code.                                     */
/* Please enter your own system, name, class, and printer stream name.         */
/* --------------------------------------------------------------------------- */
#ifndef TOOLS
#define TOOLS

#define UNIX
#define NAME    "Louis Notarino"
#define CLASS   "CSCI 2212"
#define PRN     "prn"

#include <stdio.h>      
#include <stdlib.h>     /* for malloc() and calloc()*/     
#include <math.h>        
#include <string.h>     /* for time_t, time() and ctime()*/   
#include <time.h>        
#include <ctype.h>      /* for isspace() and isdigit() */ 
#include <limits.h>     /* for INT_MAX */   
#include <float.h>      /* for DOUBLE_MAX, etc. */
#include <stdarg.h>     /* for functions with variable # of arguments */
//#include <stdbool.h>    /* for boolean type */
//#include <unistd.h>     /* for usleep */

#define PI  3.1415927                                          
#define ENATURAL  2.7182818284590451
#define GRAVITY   9.80665      /* m/sec squared; sea level and latitude 45 degrees */

typedef char * string;
typedef FILE * stream;
//typedef enum {false, true} bool;

/* --------------------------------------------------------------------------- */
/* Macros to make more convenient use of standard library functions.           */
/* --------------------------------------------------------------------------- */
#define strequal(a,b)   	!strcmp(a,b)
#define strnequal(a,b,n)  	!strncmp(a,b,n)
 
/* --------------------------------------------------------------------------- */
/* Portable definition; requires user to #define name of local system.         */
/* --------------------------------------------------------------------------- */
void    clearscreen( void );             

/* --------------------------------------------------------------------------- */
/* Routine screen and process management.------------------------------------- */
/* --------------------------------------------------------------------------- */
void    fbanner( stream sout );
void    banner( void );
void    say( string format, ... );
void 	delay ( int );	// seconds to wait
void 	mdelay( int );	// milliseconds to wait
void    hold( void );                                    
void    bye( void );                                    

/* --------------------------------------------------------------------------- */
/* Error handling. ----------------------------------------------------------- */
/* --------------------------------------------------------------------------- */
int     fatal( string format, ... );
void    cleanline( stream sin );     
void 	clean_and_log( stream sin, stream sout );

/* --------------------------------------------------------------------------- */
/* Time and date. -------------------------------------------------------------*/
/* --------------------------------------------------------------------------- */
void    when( char date[], char hour[] );
string  today( char date[] );
string  oclock( char hour[] );

/* --------------------------------------------------------------------------- */
/* Miscellaneous:  random numbers and menu handling.                           */
/* --------------------------------------------------------------------------- */
char    menu_c( string title, int n, const string menu[] );                              
int     menu_i( string title, int n, const string menu[] );      
int     evenly ( int range );
double  randy  ( );
//int		round( double d );

#endif