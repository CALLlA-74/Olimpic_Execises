// to_the_begining_of_the_line.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <stdio.h>
#include <iostream>
#include <math.h>
using namespace std;

struct Treap {
    int key, prior, count;
    Treap* left = NULL, * right = NULL;
    Treap(int key, int prior): key(key), count(count), prior(prior){}
};
typedef Treap* trp;
trp root = NULL, r1 = NULL, r2 = NULL, r3 = NULL;

int getCount(trp nd) {
    return nd ? nd->count : 0;
}

void renewCount(trp nd) {
    if (nd)
        nd->count = 1 + getCount(nd->left) + getCount(nd->right);
}

void split(trp node, trp &l, trp &r, int pos) {
    if (!node) return void(l = r = 0);
    if (pos <= getCount(node->left)) split(node->left, l, node->left, pos), r = node;
    else split(node->right, node->right, r, pos - 1 - getCount(node->left)), l = node;
    renewCount(node);
}

void merch(trp &node, trp left, trp right) {
    if (!left || !right) node = left ? left : right;
    else if (left->prior > right->prior) merch(left->right, left->right, right), node = left;
    else merch(right->left, left, right->left), node = right;
    renewCount(node);
}

void init(trp &node, trp newNode, int position) {
    trp nd1 = NULL, nd2 = NULL;
    split(node, nd1, nd2, position);
    merch(nd1, nd1, newNode);
    merch(node, nd1, nd2);
}

void outLine(trp nd) {
    if (!nd) return;
    outLine(nd->left);
    cout << nd->key << " ";
    outLine(nd->right);
}

int main()
{
    int n, m, l, r, i; cin >> n >> m;
    for (i = 0; i < n; i++) init(root, new Treap(i+1, rand()), i);
    for (i = 0; i < m; i++) {
        cin >> l >> r;
        split(root, r2, r3, r);
        split(r2, r1, r2, l - 1);
        merch(root, r2, r1);
        merch(root, root, r3);
    }
    outLine(root);
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
