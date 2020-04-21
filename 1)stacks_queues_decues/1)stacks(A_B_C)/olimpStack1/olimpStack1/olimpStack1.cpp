// olimpStack1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
using namespace std;

long length = 100;
long head   = -1;
int* stack;

long lengthLog = 100; 
long headLog= -1;
string* Log;


bool push(int n) {
    if (head + 1 >= length) {
        int* s = new int[length * 2];
        for (long i = 0; i <= head; i++)
            s[i] = stack[i];
        length *= 2;
        stack = s;
    }
    head++;
    stack[head] = n;
    return true;
}

bool pushLog(string msg) {
    if (headLog + 1 >= lengthLog) {
        string* s = new string[lengthLog * 2];
        for (long i = 0; i <= headLog; i++)
            s[i] = Log[i];
        lengthLog *= 2;
        Log = s;
    }
    headLog++;
    Log[headLog] = msg;
    return true;
}

string pop() {
    if (head < 0) return "error";
    int temp = stack[head];
    head--;
    if (head < length / 4) {
        int* s = new int[length / 2];
        for (long i = 0; i <= head; i++)
            s[i] = stack[i];
        length /= 2;
        stack = s;
    }
    return to_string(temp);
}

string back() {
    if (head < 0) return "error";
    return to_string(stack[head]);
}

string size() {
    return to_string(head + 1);
}

bool clear() {
    free(stack);
    length = 100;
    stack = new int[length];
    head = -1;
    return true;
}

int main()
{
    stack = new int[length];
    Log   = new string[lengthLog];

    while (true)
    {
        string message; cin >> message;
        if (message == "push") {
            int n; cin >> n;
            if (push(n)) pushLog("ok");
        }
        else if (message == "pop") {
            pushLog(pop());
        }
        else if (message == "back")
            pushLog(back());
        else if (message == "size")
            pushLog(size());
        else if (message == "clear") {
            if (clear()) pushLog("ok");
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
