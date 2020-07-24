// MOUSE_MOVIE_2_0.cpp : Определяет точку входа для приложения.
//

#include "framework.h"
#include "MOUSE_MOVIE_2_0.h"
#include <process.h>
#include <fstream>
using namespace std;


#define MAX_LOADSTRING 100

// Глобальные переменные:
HINSTANCE hInst;                                // текущий экземпляр
WCHAR szTitle[MAX_LOADSTRING];                  // Текст строки заголовка
WCHAR szWindowClass[MAX_LOADSTRING];            // имя класса главного окна

bool                isEnd   = false;
bool                isStart = false;

int               period;                     // значение периода, с которым будет имитироваться нажатие

// экземпляры для работы с файлом
ifstream in;
ofstream out;

// Отправить объявления функций, включенных в этот модуль кода:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPWSTR    lpCmdLine,
    _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);
    
    // TODO: Разместите код здесь.

    // Инициализация глобальных строк
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_MOUSEMOVIE20, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Выполнить инициализацию приложения:
    if (!InitInstance(hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MOUSEMOVIE20));

    MSG msg;

    // Цикл основного сообщения:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int)msg.wParam;
}



//
//  ФУНКЦИЯ: MyRegisterClass()
//
//  ЦЕЛЬ: Регистрирует класс окна.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MOUSEMOVIE20));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_MOUSEMOVIE20);
    wcex.lpszClassName = szWindowClass;
    wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   ЦЕЛЬ: Сохраняет маркер экземпляра и создает главное окно
//
//   КОММЕНТАРИИ:
//
//        В этой функции маркер экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится главное окно программы.
//

void fileWasDelete() {                     // если файла с сохраненным значением не существует, то
    in.close();
    out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");  // создаем его заново
    out << 5;                                                          // значение по умолчанию 5
    out.close();
    in.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
}

void showMenu(HWND hWnd) {
    HMENU mainMenu   = CreateMenu();
    HMENU fileMenu   = CreatePopupMenu();
    HMENU periodMenu = CreatePopupMenu();
    HMENU helpMenu   = CreatePopupMenu();
    in.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
    struct stat fileInfo;
    if (stat("C:\\Users\\Public\\Documents\\mouse_move_database.txt", &fileInfo) == -1) fileWasDelete();                                             // проверка существования файла

    short checkedItems[10]; for (short i = 0; i < 10; i++) checkedItems[i] = 0;
    short tmp; in >> tmp;
    checkedItems[tmp - 1] = 1;
    period = tmp * 120;

    AppendMenu(mainMenu, MF_POPUP, (UINT)fileMenu, L"&Файл");                                // Раздел Файл
    {
        AppendMenu(fileMenu, MF_STRING, ID_START, L"Старт                            f11");
        AppendMenu(fileMenu, MF_STRING, ID_STOP, L"Стоп                             Esc");
        AppendMenu(fileMenu, MF_STRING, IDM_EXIT, L"Вы&ход");
    }

    AppendMenu(mainMenu, MF_POPUP, (UINT)periodMenu, L"&Период");                            // Раздел Период
    {
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[0], ID_1, L"1  минута");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[1], ID_2, L"2  минуты");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[2], ID_3, L"3  минуты");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[3], ID_4, L"4  минуты");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[4], ID_5, L"5  минут");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[5], ID_6, L"6  минут");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[6], ID_7, L"7  минут");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[7], ID_8, L"8  минут");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[8], ID_9, L"9  минут");
        AppendMenu(periodMenu, MF_STRING | MF_CHECKED * checkedItems[9], ID_10, L"10 минут");
    }

    AppendMenu(mainMenu, MF_POPUP, (UINT)helpMenu, L"&Справка");                             //Раздел Справка
    AppendMenu(helpMenu, MF_STRING, IDM_ABOUT, L"&О программе...");

    in.close();
    SetMenu(hWnd, mainMenu); 
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
    hInst = hInstance; // Сохранить маркер экземпляра в глобальной переменной

    HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, 0, 300, 150, nullptr, nullptr, hInstance, nullptr);

    if (!hWnd)
    {
        return FALSE;
    }
    showMenu(hWnd);                 // отобразить меню сверху 
    SetWindowText(hWnd, L"(Остановлено)  MOUSE_MOVIE_2_0");
    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);

    return TRUE;
}

void Timing() {                                     // функция имитации нажатия на CAPS LOCK с заданным периодом
    if (isEnd) { 
        isEnd = false; 
        return; 
    }
    keybd_event(0x14, 0, 0, 0);
    keybd_event(0x14, 0, KEYEVENTF_KEYUP, 0);
    Sleep(10);
    keybd_event(0x14, 0, 0, 0);
    keybd_event(0x14, 0, KEYEVENTF_KEYUP, 0);
    for (int i = 0; i < period; i++) {
        if (isEnd) {
            isEnd = false;
            return;
        }
        Sleep(500);
    }
    Timing();
}

//
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  ЦЕЛЬ: Обрабатывает сообщения в главном окне.
//
//  WM_COMMAND  - обработать меню приложения
//  WM_PAINT    - Отрисовка главного окна
//  WM_DESTROY  - отправить сообщение о выходе и вернуться
//
//

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        // Разобрать выбор в меню:
        switch (wmId)
        {
        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        case ID_START:
            if (!isStart) isStart = true, _beginthread((_beginthread_proc_type)Timing, 0, NULL);
            SetWindowText(hWnd, L"(Запущено)  MOUSE_MOVIE_2_0");
            break;
        case ID_STOP:
            if (isStart) isEnd = true, isStart = false;
            SetWindowText(hWnd, L"(Остановлено)  MOUSE_MOVIE_2_0");
            break;
        case ID_1:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 1;
            out.close();
            showMenu(hWnd);
            break;
        case ID_2:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 2;
            out.close();
            showMenu(hWnd);
            break;
        case ID_3:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 3;
            out.close();
            showMenu(hWnd);
            break;
        case ID_4:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 4;
            out.close();
            showMenu(hWnd);
            break;
        case ID_5:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 5;
            out.close();
            showMenu(hWnd);
            break;
        case ID_6:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 6;
            out.close();
            showMenu(hWnd);
            break;
        case ID_7:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 7;
            out.close();
            showMenu(hWnd);
            break;
        case ID_8:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 8;
            out.close();
            showMenu(hWnd);
            break;
        case ID_9:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 9;
            out.close();
            showMenu(hWnd);
            break;
        case ID_10:
            out.open("C:\\Users\\Public\\Documents\\mouse_move_database.txt");
            out << 10;
            out.close();
            showMenu(hWnd);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
    }
    break;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        // TODO: Добавьте сюда любой код прорисовки, использующий HDC...
        EndPaint(hWnd, &ps);
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    case WM_KEYDOWN:
        if (wParam == 0x7A && !isStart) isStart = true, _beginthread((_beginthread_proc_type)Timing, 0, NULL), SetWindowText(hWnd, L"(Запущено)  MOUSE_MOVIE_2_0");;
        if (wParam == 0x1B && isStart) isEnd = true, isStart = false, SetWindowText(hWnd, L"(Остановлено)  MOUSE_MOVIE_2_0");;
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Обработчик сообщений для окна "О программе".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
