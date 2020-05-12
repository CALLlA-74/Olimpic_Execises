// sceleton_graph.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

struct node {
    node* next = NULL;
    short a;
    short b;
};

node** weight_of_graph;
int max_weight = 100000;
int* parent, *Rank;
int res = 0;
int cnt = 0;

void add_node(short a, short b, int w) {
    node* tmp = weight_of_graph[w];
    node* lastNode = NULL;
    if (!tmp) {
        weight_of_graph[w] = new node[1];
        weight_of_graph[w]->a = a;
        weight_of_graph[w]->b = b;
        return;
    }
    while (tmp){
        lastNode = tmp;
        tmp = tmp->next;
    }
    tmp = new node[1];
    tmp->a = a;
    tmp->b = b;
    lastNode->next = tmp;
}

int find_set(int value) {
    if (parent[value] == value)
        return value;
    return (parent[value] = find_set(parent[value]));
}

void union_sets(short a, short b, int w) {
    a = find_set(a);
    b = find_set(b);

    if (Rank[a] < Rank[b])
        swap(a, b);
    parent[b] = a;
    if (a != b) {
        Rank[a] += Rank[b];
        Rank[a] += w;
        res = Rank[a];
        cnt++;
    }
}

int main()
{
    int m, n; cin >> n >> m;
    parent = new int[n];
    Rank = new int[n];
    weight_of_graph = new node*[max_weight];
    for (int i = 0; i < max_weight; i++) weight_of_graph[i] = NULL;
    for (int i = 0; i < n; i++) {
        parent[i] = i;
        Rank[i] = 0;
    }
    for (int i = 0; i < m; i++) {
        short a, b; int w; cin >> a >> b >> w;
        add_node(a - 1, b - 1, w - 1);
    }

    for (int i = 0; i < max_weight; i++) {
        if (cnt >= n - 1) break;
        node* tmp = weight_of_graph[i];
        while (tmp) {
            if (cnt >= n - 1) break;
            union_sets(tmp->a, tmp->b, i + 1);
            tmp = tmp->next;
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
