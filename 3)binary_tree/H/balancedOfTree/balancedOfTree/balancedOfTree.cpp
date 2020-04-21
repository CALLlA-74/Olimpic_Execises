// HighOfTree.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <cmath>
using namespace std;

bool isBalanced = true;

typedef struct _node {
    int key;
    _node* left;
    _node* right;
};

_node* crnode(int value) {
    _node* nNode = new _node[1];
    nNode->key = value;
    nNode->left = NULL;
    nNode->right = NULL;
    return nNode;
}

_node* createTree(_node* root, int value) {
    if (root == NULL) root = crnode(value);
    if (root->key > value)
        if (root->left == NULL)
            root->left = crnode(value);
        else
            createTree(root->left, value);
    if (root->key < value)
        if (root->right == NULL)
            root->right = crnode(value);
        else
            createTree(root->right, value);
    return root;
}

int max(int a, int b) {
    if (b > a) return b;
    return a;
}

int CountOfNodes(_node* root) {
    if (root != NULL) return 1 + max(CountOfNodes(root->left), CountOfNodes(root->right));
    return NULL;
}

void BalancedOfTree(_node* root) {
    if (abs(CountOfNodes(root->left) - CountOfNodes(root->right)) > 1) isBalanced = false;
    if (root->left != NULL) BalancedOfTree(root->left);
    if (root->right != NULL) BalancedOfTree(root->right);
}

int main()
{
    int e; cin >> e;
    _node* tree = createTree(NULL, e);
    while (true) {
        int e; cin >> e;
        if (e == 0) break;
        tree = createTree(tree, e);
    }
    BalancedOfTree(tree);
    if (isBalanced) cout << "YES";
    else cout << "NO";
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
