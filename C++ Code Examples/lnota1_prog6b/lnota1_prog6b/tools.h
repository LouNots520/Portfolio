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

#define PI  3.1415927                                          

typedef char * cstring;
typedef FILE * stream;
//typedef enum {false, true} bool;
 
/* --------------------------------------------------------------------------- */
/* Portable definition; requires user to #define name of local system.         */
/* --------------------------------------------------------------------------- */
void    clearscreen( void );             

/* --------------------------------------------------------------------------- */
/* Routine screen and process management.------------------------------------- */
/* --------------------------------------------------------------------------- */
void    fbanner( stream sout );
void    banner( void );
void    say( cstring format, ... );
void 	delay ( int );	// seconds to wait
void    hold( void );                                    
void    bye( void );                                    

/* --------------------------------------------------------------------------- */
/* Error handling. ----------------------------------------------------------- */
/* --------------------------------------------------------------------------- */
int     fatal( cstring format, ... );
void    cleanline( stream sin );     
void 	clean_and_log( stream sin, stream sout );

/* --------------------------------------------------------------------------- */
/* Time and date. -------------------------------------------------------------*/
/* --------------------------------------------------------------------------- */
void    when( char date[], char hour[] );
cstring  today( char date[] );
cstring  oclock( char hour[] );

/* --------------------------------------------------------------------------- */
/* Miscellaneous:  random numbers and menu handling.                           */
/* --------------------------------------------------------------------------- */
char    menu_c( cstring title, int n, const cstring menu[], const cstring valid );                              
int     menu_i( cstring title, int n, const cstring menu[] );      
int     evenly ( int range );
double  randy  ( );

#endif