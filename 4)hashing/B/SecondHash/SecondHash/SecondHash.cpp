// FirstHash.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

typedef struct node {
    struct node* next = NULL;
    char s[10];
};

int tableSize = 10000;
node** HashTable = new node * [tableSize];

bool equal(string s1, string s2) {
    return (s1 == s2);
}

bool findValue(int value, string s) {
    bool isYes = false;
    node* tmp = HashTable[value % tableSize];
    while ((tmp != NULL) && (!isYes)) {
        if (equal(tmp->s, s)) isYes = true;
        tmp = tmp->next;
    }
    return isYes;
}

void insertNode(int value, string s) {

    node* tmp, * newNode;
    newNode = new node[1];
    int idx = value % tableSize;
    tmp = HashTable[idx];
    HashTable[idx] = newNode;
    newNode->next = tmp;
    for (int i = 0; i < s.size(); i++) newNode->s[i] = s[i];
}

void remove(int value, string s) {
    node* currNode, *tmp;
    currNode = HashTable[value % tableSize];
    tmp = NULL;
    while (currNode && (!equal(currNode->s, s))) {
        tmp = currNode;
        currNode = currNode->next;
    }
    if (!currNode) return;
    if (tmp) tmp->next = currNode->next;
    else HashTable[value % tableSize] = currNode->next;
    free(currNode);
}

void clear() {
    for (int i = 0; i < tableSize; i++) HashTable[i] = NULL;
}

int main()
{
    clear();
    bool* log = new bool[2000000];
    int idx = 0;
    while (true) {
        char e; cin >> e;
        if (e == '#') break;
        string s; cin >> s; int value = 0;
        int length;
        if (s.size() < 10) length = s.size();
        else length = 10;
        for (int i = 0; i < length; i++) value += s[i];
        if (e == '+') insertNode(value, s);
        if (e == '-') remove(value, s);
        if (e == '?') {
            log[idx] = findValue(value, s);
            idx++;
        }
    }

    for (int i = 0; i < idx; i++)
        if (log[i]) cout << "YES" << endl;
        else cout << "NO" << endl;
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
