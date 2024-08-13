/*
 - Для float нужно добавлять суфикс 'f' или 'F'
 - Для decimal нужно добавлять суфикс 'm' или 'M'
 - Для ulong нужно добавлять суфикс 'ul' или 'UL'
 - Для long нужно добавлять суфикс 'l' или 'L'
 - Для uint нужно добавлять суфикс 'u' или 'U' 
 */


//Неявная типизация

var age  = 10; 
var name = "name";

const int maxInt = int.MaxValue;
const int minInt = int.MinValue;
const double pi = 3.14159;

///Преобразование типов
int x = 10;
long lx = x; //Тут не явное преобразование типов из int в long

double d = 21.567;
int y = (int)d; // Явное преобразование типов из double в int


//Числовые разделители 

int billion = 1_000_000_000;
double  avagadro = 6.022_140_73e23;
