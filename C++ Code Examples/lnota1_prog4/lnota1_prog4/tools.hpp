// file: tools.h ---------------------------------------------------- 
// header file for the C++ tools library.   
// modified October 2013

#pragma once
// -------------------------------------------------------------------
// Local definitions and portability code.
// Please enter your own system, name, class, and printer stream name.
// -------------------------------------------------------------------
#define NAME    "Louis Notarino"
#define CLASS   "CSCI 2212"
#define UNIX            // OR,  define VISUAL

#include <cctype>		// for isspace() and isdigit() 
#include <cfloat>		// for DOUBLE_MAX, etc. 
#include <cstdarg>		// for functions with variable # of arguments

#include <cstdio>       // for NULL 
#include <cstdlib>      // for malloc() and calloc()
#include <cstring>      // The C string library 
#include <cmath>
#include <ctime>		// for time_t, time() and ctime()
#include <limits>       // for INT_MAX 

#include <iostream>		// for screen and keyboard IO
#include <fstream>
#include <sstream>
#include <iomanip>
#include <algorithm>	// for sort
#include <string>		// for strings that grow as needed
#include <vector>       // for growing arrays

using namespace std;
typedef char* cstring;
typedef const char* const_cstring;
// -------------------------------------------------------------------
// Macros to make more convenient use of standard library functions.
// Note:  A macro must be entirely on one line.
// -------------------------------------------------------------------
#define DUMPp(p) "\n"<<hex<<"   " #p " @ "<<(unsigned)&p<<"   value = "<<(unsigned)p<<"   " #p " --> "<<dec<<*p
#define DUMPv(k) "\n"<<hex<<"   " #k " @ "<<(unsigned)&k<<"   value = "<<dec<<k

// -------------------------------------------------------------------
// Portable definitions; these require user to #define name of local system.
// -------------------------------------------------------------------
void    clearscreen( void );
void    bye( void );

// -------------------------------------------------------------------
// Routine screen and process management.-----------------------------
// -------------------------------------------------------------------
void     fbanner( ostream& fout );
#define  banner()  fbanner( cout )
void     delay( int );
void     hold( void );
void     say( const char* format, ... );

// -------------------------------------------------------------------
// I/O Extension. ---------------------------------------------------- 
// -------------------------------------------------------------------
istream&  flush( istream& is );   // Used in cin >>x >>flush;

// -------------------------------------------------------------------
// Error handling. ---------------------------------------------------
// -------------------------------------------------------------------
void    fatal( const char* format, ... );
void    cleanline( istream& sin );     

// -------------------------------------------------------------------
// Time and date. ----------------------------------------------------
// -------------------------------------------------------------------
void   when ( char* date, char* hour );
char*  today( char* date );
char*  oclock( char* hour );

// ----------------------------------------------------------------------------- 
// Miscellaneous:  random numbers and menu handling.                           
// ----------------------------------------------------------------------------- 
char  menu_c( const_cstring title, int n, const_cstring menu[], const_cstring valid );                              
int   menu_i( const_cstring title, int n, const_cstring menu[] );      
double  randy  ( );				   // Returns random number bewtween 0.0 and 1.0