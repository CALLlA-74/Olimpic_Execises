// heaps.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

typedef struct {
    int* heap;
} heap;

heap Heap;
int* Log;

void add(int idx, int x, int idxLog){
    Heap.heap[idx] += x;
    int parentIdx = (idx - 1) / 2;
    while (parentIdx + 1 && Heap.heap[idx] > Heap.heap[parentIdx]){
        int y = Heap.heap[idx];
        Heap.heap[idx] = Heap.heap[parentIdx];
        Heap.heap[parentIdx] = y;
        idx = parentIdx;
        parentIdx = (idx - 1)/2;
    }
    Log[idxLog] = idx+1;
}

int main()
{
    int n, len; cin >> len;
    Heap.heap = new int[len];

    for (int i = 0; i < len; i++)
        cin >> Heap.heap[i];

    cin >> n;

    Log = new int[n];

    for (int i = 0; i < n; i++) {
        int idx, x; 
        cin >> idx >> x;
        add(idx-1, x, i);
    }

    for (int i = 0; i < n; i++)
        cout << Log[i] << endl;
    for (int i = 0; i < len; i++)
        cout << Heap.heap[i] << " ";
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
