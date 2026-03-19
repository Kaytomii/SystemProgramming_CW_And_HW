#include "pch.h"
#include "PointManager.h"
#include <iostream>

PointManager::PointManager(int cap) : capacity(cap), count(0)
{
	x = new int[capacity];
	y = new int[capacity];
}

void PointManager::PrintAllPoints() const
{
	if (count == 0)
	{
		std::cout << "No points\n";
		return;
	}

	for (int i = 0; i < count; ++i)
	{
		std::cout << "Index " << i << ": x = " << x[i] << ", y = " << y[i] << "\n";
	}
}

void PointManager::AddPoint(int px, int py)
{
	if (count >= capacity)
	{
		return;
	}

	x[count] = px;
	y[count] = py;
	count++;
}

void PointManager::RemovePoint(int index)
{
	if (index < 0 || index >= count)
	{
		return;
	}

	for (int i = index; i < count - 1; ++i)
	{
		x[i] = x[i + 1];
		y[i] = y[i + 1];
	}
	count--;
}

void PointManager::GetPoint(int index, int* outX, int* outY)
{
	if (index < 0 || index >= count)
	{
		std::cout << "Incorrect index";
		return;
	}

	*outX = x[index];
	*outY = y[index];

	std::cout << "Point x: " << *outX << "\n";
	std::cout << "Point y: " << *outY << "\n";
}

int PointManager::Count() const
{
	return count;
}

PointManager::~PointManager()
{
	delete[] x;
	delete[] y;
}
