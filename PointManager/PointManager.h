#pragma once
class PointManager
{
private:
	int* x;
	int* y;
	int capacity;
	int count;

public:
	PointManager(int cap);

	void PrintAllPoints() const;
	void AddPoint(int px, int py);
	void RemovePoint(int index);
	void GetPoint(int index, int* outX, int* outY);
	int Count() const;
	~PointManager();
};