// cut_the_graph.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int* parent, **requests;
bool* Log;

int find_set(int value) {
    if (value == parent[value]) return value;
    return parent[value] = find_set(parent[value]);
}

void union_sets(int a, int b) {
    a = find_set(a);
    b = find_set(b);
    parent[b] = a;
}

int main()
{
    int n, m, k; cin >> n >> m >> k;
    parent = new int[n];
    requests = new int*[k];
    Log = new bool[k] ;
    for (int i = 0; i < m; i++) {
        int a; cin >> a >> a;
    }
    for (int i = 0; i < n; i++) parent[i] = i;
    for (int i = 0; i < k; i++) {
        requests[i] = new int[3];
        string s; cin >> s >> requests[i][1] >> requests[i][2];
        if (s[0] == 'c') requests[i][0] = 0;
        else requests[i][0] = 1;
    }
    for (int i = k - 1; i >= 0; i--) {
        if (!requests[i][0]) union_sets(requests[i][1] - 1, requests[i][2] - 1);
        else Log[i] = (find_set(requests[i][1] - 1) == find_set(requests[i][2] - 1));
    }
    for (int i = 0; i < k; i++) {
        if (requests[i][0]) {
            if (Log[i]) cout << "YES" << endl;
            else cout << "NO" << endl;
        }
    }
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
