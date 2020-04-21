#include <iostream>
#include <string>
using namespace std;

int* Deque;
long length = 100;
long head = length/2;
long trail = length/2-1;

string* Log;
long lengthLog = 1000000;
long headLog = -1;

bool isFirst = true;

void push_front(int n) {
    if (isFirst) {
        trail++;
        Deque[head] = n;
        isFirst = false;
        return;
    }

    if (head <= 0) {
        int* s = new int[length * 2];
        long j = length/2;
        for (long i = 0; i <= trail; i++) {
            s[j] = Deque[i];
            j++;
        }    
        Deque = s;
        head = length/2;
        trail += head;
        length *= 2;
    }
    head--;
    Deque[head] = n;
}

void push_back(int n) {
    if (isFirst) {
        trail++;
        Deque[head] = n;
        isFirst = false;
        return;
    }

    if (trail + 1 >= length) {
        int* s = new int[length * 2];
        long j = length + length/2;
        for (long i = trail; i >= head; i--) {
            s[j] = Deque[i];
            j--;
        }
        trail = length + length / 2;
        head = j+1;
        length *= 2;
        Deque = s;
    }
    trail++;
    Deque[trail] = n;
}

void pushLog(string msg) {
    if (headLog + 1 >= lengthLog) {
        string* s = new string[lengthLog + 1000000];
        for (long i = 0; i <= headLog; i++)
            s[i] = Log[i];
        lengthLog += 1000000;
        Log = s;
    }
    headLog++;
    Log[headLog] = msg;
}

string pop_front() {
    if (trail < head) return "error";
    int temp = Deque[head];
    head++;
    /*if (tail < length / 4) {
        int* s = new int[length / 2];
        for (long i = 0; i <= tail; i++)
            s[i] = Deque[i];
        head = 0;
        length /= 2;
        Deque = s;
    }*/
    return to_string(temp);
}

string pop_back() {
    if (trail < head) return "error";
    int temp = Deque[trail];
    trail--;
    /*if (tail < length / 4) {
        int* s = new int[length / 2];
        for (long i = 0; i <= tail; i++)
            s[i] = Deque[i];
        head = 0;
        length /= 2;
        Deque = s;
    }*/
    return to_string(temp);
}

string front() {
    if (trail < head) return "error";
    return to_string(Deque[head]);
}

string back() {
    if (trail < head) return "error";
    return to_string(Deque[trail]);
}

string size() {
    return to_string(trail - head + 1);
}

void clear() {
    free(Deque);
    length = 100;
    head = length/2;
    Deque = new int[length];
    trail = length / 2 - 1;
    isFirst = true;
}

int main()
{
    Deque = new int[length];
    Log = new string[lengthLog];

    while (true)
    {
        string message; cin >> message;
        if (message == "push_front") {
            int n; cin >> n; push_front(n); pushLog("ok");
        }
        else if (message == "push_back") {
            int n; cin >> n; push_back(n); pushLog("ok");
        }
        else if (message == "pop_front") {
            pushLog(pop_front());
        }
        else if (message == "pop_back") {
            pushLog(pop_back());
        }
        else if (message == "front") {
            pushLog(front());
        }
        else if (message == "back") {
            pushLog(back());
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

    for (long i = 0; i <= headLog; i++) {
        cout << Log[i] << endl;
    }
}