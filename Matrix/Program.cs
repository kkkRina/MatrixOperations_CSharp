using Matrixx;

var m1 = new Matrix(); // матрица - 0
Console.WriteLine("Нуль-матрица m1 : ");
Console.WriteLine(m1);

var m2 = new Matrix(4, 10); // нулевая матрица заданного размера
Console.WriteLine("Нулевая матрица заданного размера m2 : ");
Console.WriteLine(m2);

double[,] el1 = { { 1.0,2,3 },{ 4,5,6 },{ 7,8,9 } };
var m3 = new Matrix(el1); // создание матрицы по массиву
Console.WriteLine("Матрица, созданная по массиву -  m3 : ");
Console.WriteLine(m3);

var m4 = m3; // копирование
Console.WriteLine("Копировани m3 в m4 : ");
Console.WriteLine(m4);

Console.WriteLine($"Размеры m2 = {m2.Rows} * {m2.Cols}");

Console.WriteLine($"m3[2,3] = {m3[1, 2]}");
Console.WriteLine($"m3[5,0] = {m3[5, 0]}");

Console.WriteLine($"m3 == m4 {m3 == m4}");
Console.WriteLine($"m1 != m2 {m1 != m2}");

double[,] el2 = { {1,0,1 }, {0,1,0 }, {1,0,1 } };
var m5 = new Matrix(el2);
Console.WriteLine("m3+m5=");
Console.WriteLine($"{m3} + \n{m5} = \n{m3 + m5}");
Console.WriteLine("m3-m5=");
Console.WriteLine($"{m3} - \n{m5} = \n{m3 - m5}");
Console.WriteLine("m5*9=");
Console.WriteLine(m5 * 9);
Console.WriteLine("m3/2=");
Console.WriteLine(m3 / 2);

double[,] el3 = { {1,2,3 }, {1,2,3 } };
double[,] el4 = { { 1, 1 }, { 2, 2 }, { 3, 3 } };
var m6 = new Matrix(el3);
var m7 = new Matrix(el4);
Console.WriteLine("m6*m7=");
Console.WriteLine($"{m6} * \n{m7} = \n{m6 * m7}");

Console.WriteLine($"Транспонированная m4 : \n{m4.Trmatrix}");

////////////////
var sm1 = new SquareMatrix(); // 0
Console.WriteLine("sm1 : ");
Console.WriteLine(sm1);

var sm2 = new SquareMatrix(4); // нулевая матрица заданного размера
Console.WriteLine("sm2 : ");
Console.WriteLine(sm2);

var sm3 = new SquareMatrix(el1); // создание матрицы по массиву
Console.WriteLine("sm3 : ");
Console.WriteLine(sm3);

var sm4 = sm3; // копирование
Console.WriteLine("sm4 : ");
Console.WriteLine(sm4);

Console.WriteLine($"Размеры sm2 = {sm2.Rows} * {sm2.Cols}");

var sm5 = new SquareMatrix(m3); 
Console.WriteLine("Присваивание sm5 значения sm3 : ");
Console.WriteLine(sm5);

double[,] el5 = { { 3, 4 }, { 5, 7 } };
var sm6 = new SquareMatrix(el5);

Console.WriteLine($"Определитель матрицы sm3 = {sm3.Determinant}");
Console.WriteLine($"Определитель матрицы sm6 = {sm6.Determinant}");
Console.WriteLine($"Обратная матрица для sm6 = \n{sm6.InvMatrix}");

Console.WriteLine($"Хэш-код m1: {m1.GetHashCode()}");
Console.WriteLine($"Хэш-код m2: {m2.GetHashCode()}");
Console.WriteLine($"Хэш-код m3: {m3.GetHashCode()}");
Console.WriteLine($"Хэш-код m4: {m4.GetHashCode()}");
Console.WriteLine($"Хэш-код m5: {m5.GetHashCode()}");
Console.WriteLine($"Хэш-код m6: {m6.GetHashCode()}");

Console.WriteLine($"Хэш-код sm1: {sm1.GetHashCode()}");
Console.WriteLine($"Хэш-код sm2: {sm2.GetHashCode()}");
Console.WriteLine($"Хэш-код sm3: {sm3.GetHashCode()}");
Console.WriteLine($"Хэш-код sm4: {sm4.GetHashCode()}");
Console.WriteLine($"Хэш-код sm5: {sm5.GetHashCode()}");
Console.WriteLine($"Хэш-код sm6: {sm6.GetHashCode()}");

Console.WriteLine($"sm3.equals(sm5) : {sm3.Equals(sm5)}");
Console.WriteLine($"sm1.equals(sm5) : {sm1.Equals(sm5)}");