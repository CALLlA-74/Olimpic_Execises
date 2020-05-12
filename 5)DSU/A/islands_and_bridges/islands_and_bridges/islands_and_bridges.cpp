// islands_and_bridges.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int* parent, *Rank;

int find_set(int value) {
	if (value == parent[value]) return value;
	return (parent[value] = find_set(parent[value]));
}

void union_sets(int a, int b) {
	//a = find_set(a);
	//b = find_set(b);
	if (Rank[a] < Rank[b])
		swap(a, b);
	parent[b] = a;
	if (Rank[a] == Rank[b])
		++Rank[a];
}

int main()
{
	int m, n, res; cin >> n >> m;
	parent = new int[n];
	Rank = new int[n];
	for (int i = 0; i < n; i++) {
		parent[i] = i;
		Rank[i] = 0;
	}
	for (int i = 0; i < m; i++) {
		int a, b; cin >> a >> b;
		a = find_set(a - 1);
		b = find_set(b-1);
		if (a != b) {
			union_sets(a, b);
			res = i + 1;
		}
	}
	cout << res;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
