// weight_of_component.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int* parent, *Rank;

int find_set(int value) {
    if (parent[value] == value)
        return value;
    return (parent[value] = find_set(parent[value]));
}

void union_sets(int a, int b, int w) {
    a = find_set(a);
    b = find_set(b);

    if (Rank[a] < Rank[b])
        swap(a, b);
    parent[b] = a;
    Rank[a] += w;
    if (a != b)
        Rank[a] += Rank[b];
}

int get_Rank(int value) {
    value = find_set(value);
    return Rank[value];
}

int main()
{
    int n, m; cin >> n >> m;
    parent = new int[n];
    Rank = new int[n];
    int* log = new int[m];
    int idx = 0;
    for (int i = 0; i < n; i++) {
        parent[i] = i;
        Rank[i] = 0;
    }

    for (int i = 0; i < m; i++) {
        short req; cin >> req;
        if (req == 1) {
            int x, y; int w;
            cin >> x >> y >> w;
            union_sets(x - 1, y - 1, w);
        }
        else {
            int x; cin >> x;
            log[idx] = get_Rank(x - 1);
            idx++;
        }
    }

    for (int i = 0; i < idx; i++)
        cout << log[i] << endl;
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
