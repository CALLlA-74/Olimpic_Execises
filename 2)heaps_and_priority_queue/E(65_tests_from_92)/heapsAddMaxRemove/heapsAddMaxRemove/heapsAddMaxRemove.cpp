// heapAddMax.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int* heap;
int len;
int tail = -1;

int** Log;
int  idxLog = 0;

void Extract_max() {
    if (tail < 0) {
        Log[idxLog][0] = -1;
        idxLog++;
        return;
    }
    else if (tail == 0) {
        Log[idxLog][1] = heap[0];
        Log[idxLog][0] = 0;
        tail--;
        idxLog++;
        return;
    }

    Log[idxLog][1] = heap[0];
    heap[0] = heap[tail];
    tail--;

    int idx = 0;
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
    Log[idxLog][0] = idx + 1;
    idxLog++;
}

void add(int x) {
    if (tail + 1 >= len) {
        Log[idxLog][0] = -1;
        idxLog++;
        return;
    }

    tail++;
    heap[tail] = x;
    int idx = tail;
    int parent = (idx - 1) / 2;
    while (parent >= 0 && heap[parent] < heap[idx])
    {
        int y = heap[parent];
        heap[parent] = heap[idx];
        heap[idx] = y;
        idx = parent;
        parent = (idx - 1) / 2;
    }

    Log[idxLog][0] = -2;
    Log[idxLog][1] = idx + 1;
    idxLog++;
}

void remove(int idx) {
    if (idx > tail) {
        Log[idxLog][0] = -1;
        idxLog++;
        return;
    }

    Log[idxLog][0] = -2;
    Log[idxLog][1] = heap[idx];
    idxLog++;

    heap[idx] = heap[tail];
    tail--;
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

int main()
{
    int m; cin >> len >> m;
    heap = new int[len];
    Log = new int* [m];

    for (int i = 0; i < m; i++) {
        Log[i] = new int[2];
        int type, value; cin >> type;
        switch (type)
        {
        case 1:
            Extract_max();
            break;
        case 2:
            cin >> value;
            add(value);
            break;
        case 3:
            cin >> value;
            remove(value - 1);
            break;
        }
    }

    for (int i = 0; i < idxLog; i++) {
        if (Log[i][0] == -1) cout << -1 << endl;
        else if (Log[i][0] == -2) cout << Log[i][1] << endl;
        else cout << Log[i][0] << " " << Log[i][1] << endl;
    }
    for (int i = 0; i <= tail; i++)
        cout << heap[i] << " ";
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
