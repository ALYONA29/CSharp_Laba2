#include <windows.h>

#include  "LibCPP.h"

// Вычисление m-го числа Фибоначчи
unsigned long fibonacci(unsigned long n) 
{
	unsigned long a = 0, b = 1, c; 
	if( n == 0 ) 
		return a; 
	for ( unsigned long i = 2; i <= n; i++ ) 
	{ 
		c = a + b; 
		a = b; 
		b = c; 
	} 
	return b; 
}

unsigned long __cdecl fibonacciCDECL(unsigned long m) {
	return fibonacci(m);
}

unsigned long __stdcall fibonacciSTD(unsigned long m) {
	return fibonacci(m);
}

unsigned long __fastcall fibonacciFAST(unsigned long m) {
	return fibonacci(m);
}

unsigned long fibonacciNumber::calc() {
	return fibonacci(this->number);
}

fibonacciNumber * __cdecl createFibonacci(unsigned long m) {
	return new fibonacciNumber(m); 
}


