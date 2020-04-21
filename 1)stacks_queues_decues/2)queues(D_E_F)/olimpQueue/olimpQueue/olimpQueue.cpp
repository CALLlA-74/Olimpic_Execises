// olimpQueue.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
using namespace std;

long length = 100;
long head = 0;
long tail = -1;
int* queue;

long lengthLog = 100;
long headLog = -1;
string* Log;

void push(int n) {
    if (tail + 1 >= length) {
        int* s = new int[length * 2];
        for (long i = 0; i <= tail; i++) {
            s[i] = queue[i];
        }
        length *= 2;
        queue = s;
    }
    tail++;
    queue[tail] = n;
}

void pushLog(string msg) {
    if (headLog + 1 >= lengthLog) {
        string* s = new string[lengthLog*2];
        for (long i = 0; i <= headLog; i++) {
            s[i] = Log[i];
        }
        lengthLog *= 2;
        Log = s;
    }
    headLog++;
    Log[headLog] = msg;
}

string pop() {
    if (tail < 0) return "error";
    int temp = queue[head];
    for (long i = 1; i <= tail; i++)
        queue[i - 1] = queue[i];
    tail--;
    if (tail < length / 4) {
        int* s = new int[length / 2];
        for (long i = 0; i <= tail; i++)
            s[i] = queue[i];
        length /= 2;
        queue = s;
    }
    return to_string(temp);
}

string front() {
    if (tail < 0) return "error";
    return to_string(queue[head]);
}

string size() {
    return to_string(tail + 1);
}

void clear() {
    free(queue);
    length = 100;
    queue = new int[length];
    head = 0;
    tail = -1;
}

int main()
{
    queue = new int[length];
    Log = new string[lengthLog];

    while (true)
    {
        string message; cin >> message;
        if (message == "push") {
            int n; cin >> n;
            push(n); pushLog("ok");
        }
        else if (message == "pop") {
            pushLog(pop());
        }
        else if (message == "front") {
            pushLog(front());
        }
        else if (message == "size") {
            pushLog(size());
        }
        else if (message == "clear") {
            clear(); pushLog("ok");
        }
        else if (message == "exit") {
            pushLog("bye");
            break;
        }
    }

    for (long i = 0; i <= headLog; i++)
        cout << Log[i] << endl;
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
