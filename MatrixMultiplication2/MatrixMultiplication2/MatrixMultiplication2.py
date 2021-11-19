import random

# МЕТОДЫ
#------------------------------------------------------------------------------

# Печать матрицы
# A: печатаемая матрица
def PrintMatrix(A):
    if A == None:
        return
    for i in range(len(A)):
        for j in range(len(A[0])):
            print(A[i][j], end = '\t')
        print()
    print()
    return

# Создание матрицы со случайными целыми числами в диапазоне от minVal до maxVal
# lin   : число строк матрицы
# col   : число столбцов матрицы
# minVal: минимальное вероятное значение
#         по умолчанию равно -100
# maxVal: максимальное вероятное значение
#         по умолчанию равно 100
def CrRandMatrix(lin, col, minVal = -100, maxVal = 100):
    matrix = [[random.randint( minVal, maxVal) for j in range(0, col * lin, lin)] for i in range(lin)]
    return matrix

# Произведение матриц
# A: левая матрица произведения
# B: правая матрица произведения
def MatrixMultiplication(A, B):
    if A == None or B == None:
        return
    if len(A[0]) != len(B): 
        return
    C = [[0 for j in range(len(B[0]))] for i in range(len(A))]
    for i in range(len(A)):
        for j in range(len(B[0])):
            for g in range(m):
                C[i][j] = C[i][j] + A[i][g] * B[g][j]
    return C

# ТЕСТОВЫЕ ДАННЫЕ
#------------------------------------------------------------------------------
n, m = 6, 3
k, p = 3, 5
A = [[1 + i + j for j in range(0, m * n, n)] for i in range(n)]
B = [[k*p - i - j for j in range(0, p * k, k)] for i in range(k)]
C = [[-1, 0, 1], 
    [-1, 0, 1], 
    [0, 1, -1]]
D = [[2, 0, 1], 
    [-1, 0, 1],
    [1, 0, -3]]

# Main
#------------------------------------------------------------------------------
print("A[",n,",",m,"]")
PrintMatrix(A)
print("B[",k,",",p,"]")
PrintMatrix(B)
print("A * B =")
PrintMatrix(MatrixMultiplication(A, B))

print("C[",len(C),",",len(C[0]),"]")
PrintMatrix(C)
print("D[",len(D),",",len(D[0]),"]")
PrintMatrix(D)
print("C * D =")
PrintMatrix(MatrixMultiplication(C, D))
print("D * C =")
PrintMatrix(MatrixMultiplication(D, C))

PrintMatrix(MatrixMultiplication(None, None))

print("E[",3,",",9,"]")
E = CrRandMatrix(3, 9)
PrintMatrix(E)
print("J[",9,",",2,"]")
J = CrRandMatrix(9, 2, -1, 1)
PrintMatrix(J)
print("E * J =")
PrintMatrix(MatrixMultiplication(E, J))

