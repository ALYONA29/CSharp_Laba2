#pragma once

#ifdef LIBCPP_EXPORTS
#define LIBCPP_API __declspec(dllexport)
#else
#define LIBCPP_API __declspec(dllimport)
#endif

extern "C" LIBCPP_API unsigned long __cdecl fibonacciCDECL(unsigned long m);
extern "C" LIBCPP_API unsigned long __stdcall fibonacciSTD(unsigned long m);
extern "C" LIBCPP_API unsigned long __fastcall fibonacciFAST(unsigned long m);

class LIBCPP_API fibonacciNumber {
public:
	fibonacciNumber(unsigned long m) {
		number = m;
	}
	unsigned long calc();

	unsigned long number;
};

extern "C" LIBCPP_API fibonacciNumber* __cdecl createFibonacci(unsigned long m);



