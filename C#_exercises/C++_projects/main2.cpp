#include <iostream>
#include <conio.h>
#include <algorithm>
using namespace std;



/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int rec(int**values, int m, int n, int res, int i = 0, int j = 0, int curr = 0){
	if (i == m - 1 && j== n - 1){
		curr += values[i][j];
		if (i == m - 1 && j == n - 1)
			res = min(res, curr);
		return res;
	}
	curr += values[i][j];
	if (i < m - 1)
		res = rec(values, m, n, res, i + 1, j);
	if (j < n - 1)
		res = rec(values, m, n, res, i, j + 1);
	return res;
}

int main(int argc, char** argv) {
	int m, n, **values, res;
	cin>>m>>n;
	values = new int*[m];
	for (int i = 0; i < m; i++){
		values[i] = new int[n];
		for (int j = 0; j < n; j++){
			cin >> values[i][j];
		}
	}
	res = rec(values, m, n, 100*m*n);
	cout << res;
	getch();
	return 0;
}


