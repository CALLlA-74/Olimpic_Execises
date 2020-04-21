// toHeapDown.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int* heap;
int len;
int tail;

int* sorted;

void siftDown(int idx) {
    int child1 = idx * 2 + 1;
    int child2 = idx * 2 + 2;

    while ((child1 <= tail && heap[child1] > heap[idx]) || (child2 <= tail && heap[child2] > heap[idx])) {
        int y = heap[idx];
        if (child2 <= tail && heap[child2] > heap[idx] && heap[child2] > heap[child1]) {
            heap[idx] = heap[child2];
            heap[child2] = y;
            idx = child2;
        }
        else {
            heap[idx] = heap[child1];
            heap[child1] = y;
            idx = child1;
        }
        child1 = idx * 2 + 1;
        child2 = idx * 2 + 2;
    }
}

void toHeapDown() {
    for (int i = len - 1; i >= 0; i--) {
        if (i * 2 + 1 < len)
            siftDown(i);
    }
}

void extractMax(int idx) {
    sorted[idx] = heap[0];
    heap[0] = heap[tail];
    tail--;
    siftDown(0);
}

void sort() {
    for (int i = len - 1; i >= 0; i--) {
        extractMax(i);
    }
}

int main()
{
    cin >> len; heap = new int[len];
    sorted = new int[len];
    tail = len - 1;

    for (int i = 0; i < len; i++)
        cin >> heap[i];
    toHeapDown();
    sort();
    for (int i = 0; i < len; i++)
        cout << sorted[i] << " ";
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
