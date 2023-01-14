#pragma once
#ifdef SIMULATOR_API
#undef SIMULATOR_API
#define SIMULATOR_API __declspec(dllexport)
#else
#define SIMULATOR_API __declspec(dllimport)
#endif

//extern "C" SIMULATOR_API void simulate(BYTE inputPixels[], int size, int imageWidth, int startHeight, int endHeight);

extern "C" SIMULATOR_API int test();