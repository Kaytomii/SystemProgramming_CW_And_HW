// pch.cpp: source file corresponding to the pre-compiled header

#include "pch.h"

// When you are using pre-compiled headers, this source file is necessary for compilation to succeed.
#include "PointManager.h"

extern "C"
{
	__declspec(dllexport) PointManager* CreatePointManagerObject(int cap)
	{
		return new PointManager(cap);
	}
	__declspec(dllexport) void DeletePointManagerObject(PointManager* obj)
	{
		delete obj;
	}
	__declspec(dllexport) void PrintAllPoints(PointManager* obj)
	{
		if (obj != nullptr)
		{
			return obj->PrintAllPoints();
		}
		throw "Exception: Object is nullptr";
	}
	__declspec(dllexport) void AddPoint(PointManager* obj, int px, int py)
	{
		if (obj != nullptr)
		{
			return obj->AddPoint(px, py);
		}
		throw "Exception: Object is nullptr";
	}
	__declspec(dllexport) void RemovePoint(PointManager* obj, int index)
	{
		if (obj != nullptr)
		{
			return obj->RemovePoint(index);
		}
		throw "Exception: Object is nullptr";
	}
	__declspec(dllexport) void GetPoint(PointManager* obj, int index, int* outX, int* outY)
	{
		if (obj != nullptr)
		{
			return obj->GetPoint(index, outX, outY);
		}
		throw "Exception: Object is nullptr";
	}
	__declspec(dllexport) int Count(PointManager* obj)
	{
		if (obj != nullptr)
		{
			return obj->Count();
		}
		throw "Exception: Object is nullptr";
	}
}