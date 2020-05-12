// calculator.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

struct node {
    node* next = NULL;
    int value = 0;
};

int sizeTable = 1000;
node** HashTable = new node*[sizeTable];
float res = 0;

int Hash(int value) {
    return (value % sizeTable);
}

void insertValue(int value) {
    node* newNode, *currNode, *tmp, *lastNode;
    int idx = Hash(value);
    currNode = HashTable[idx];
    newNode = new node[1];
    lastNode = NULL;

    if (!currNode) {
        HashTable[idx] = newNode;
        HashTable[idx]->value = value;
        return;
    }

    while (currNode->next && (currNode->value < value)) {
        lastNode = currNode;
        currNode = currNode->next;
    }

    newNode->value = value;

    if (currNode->next) {
        if (!lastNode) {
            HashTable[idx] = newNode;
            newNode->next = currNode;
            return;
        }
        lastNode->next = newNode;
        newNode->next = currNode;
        return;
    }
    if (currNode->value < value) {
        currNode->next = newNode;
        currNode->next->value = value;
        return;
    }
    if (!lastNode) {
        HashTable[idx] = newNode;
        newNode->next = currNode;
        return;
    }
    lastNode->next = newNode;
    newNode->next = currNode;
}

void removeValue(int value) {
    node* lastNode, *currNode;
    int idx = Hash(value);
    currNode = HashTable[idx];
    lastNode = NULL;
    if (!currNode) return;
    while (currNode->next && (currNode->value != value)) {
        lastNode = currNode;
        currNode = currNode->next;
    }
    if (currNode->value != value) return;
    if ((!lastNode) && (!currNode->next)) {
        HashTable[idx] = NULL;
        return;
    }
    if (lastNode && (!currNode->next)) {
        lastNode->next = NULL;
        return;
    }
    if ((!lastNode) && currNode->next) {
        HashTable[idx] = currNode->next;
        return;
    }
    if (lastNode && currNode->next) {
        lastNode->next = currNode->next;
    }
}

int removeMin() { // функция находит 2 наименьших эелемента и возвращает их сумму, иначе возвращает единственный элемент
    int min1 = 1000000001;
    int min2 = 1000000001; // min1 <= min2

    for (short i = 0; i < sizeTable; i++) {
        node* tmp = HashTable[i];
        if (!tmp) continue;
        if (tmp->value <= min1) {
            min2 = min1;
            min1 = tmp->value;
        }
        else if (tmp->value < min2) min2 = tmp->value;

        if (tmp->next) {
            if (tmp->next->value <= min1) {
                min2 = min1;
                min1 = tmp->next->value;
            }
            else if (tmp->next->value < min2) min2 = tmp->next->value;
        }
    }
    removeValue(min1);
    removeValue(min2);
    if ((min1 > 1000000000) && (min2 > 1000000000)) return 0;
    if (min2 > 1000000000) {
        res += min1;
        return min1;
    }
    res += (min1 + min2) * 0.05;
    return (min1 + min2);
}

void calculate(int n) {
    for (int i = 0; i < n - 1; i++) {
        insertValue(removeMin());
    }
}

void clear() {
    for (int i = 0; i < sizeTable; i++) HashTable[i] = NULL;
}

int main()
{
    clear();
    int n; cin >> n;
    for (int i = 0; i < n; i++) {
        int a; cin >> a;
        insertValue(a);
    }
    calculate(n);
    printf("%.2f", res);
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
