#include <stdio>

int f(int n, int* a){
	int res = 1; int i = 1;
	int count = 1;
	
	while (i < n){
		if (a[i] >= a[i-1]){
			count++;
		}
		else{
			res = count;
			count = 1;
		}
		i++;
	}
	if (count > res)
		res = count;
	return res;
	
}

int main(){
	int n; scanf("%d", &n);
	int a[n];
	for (int i = 0; i < n; i++){
		scanf("%d", &a[i]);
	}
	int res = f(n, a);
	printf("%d", res);
	return 0;
}
