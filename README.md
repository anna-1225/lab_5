# Лабораторная работа №5 — Построение AST и проверка контекстно-зависимых условий
## Цель работы
Изучить назначение и принципы работы семантического анализатора в структуре компилятора. Освоить методы построения абстрактного синтаксического дерева (AST) и проверки контекстно-зависимых условий (семантических правил) для заданной синтаксической конструкции.
## Автор
+ Сущих Анна Александровна
+ Группа: АП-326
## Вариант задания
Обрабатываемая конструкция
```
max = a if a > b else b;

```
## Примеры корректных строк
```
x = 10;
y = 20;
max = x if x > y else y;
```
## CST / AST (схема для корректной строки)
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/tree.png)
## Реализованные контекстно-зависимые условия
### 1. Уникальность идентификатора
```
x = 5;
x = 10;
```
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/error1.png)
### 2. Использование идентификаторов
```
max = x if x > y else y;
```
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/error2.png)
### 3. Совместимость типов
```
x = 10;
y = 20;
max = x if 42 else y;
```
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/error3.png)
### 4. Допустимые значения
```
x = 99999999999999;
```
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/error4.png)
## Структура AST
Типы узлов:
* BlockNode
* AssignNode
* ConditionalNode
* BinaryOpNode
* VariableNode
* NumberNode
## Пример AST
Для строки:
```
x = 10;
y = 20;
max = x if x > y else y;
```

```
--- Строка 1 ---
AssignNode
    Variable: a
    Value:
    NumberNode
    Value: 5

--- Строка 2 ---
AssignNode
    Variable: b
    Value:
    NumberNode
    Value: 10

--- Строка 3 ---
AssignNode
    Variable: max
    Value:
    ConditionalNode
    Condition
    BinaryOpNode (>)
    Left: a
    Right: b
    TrueValue:
    VariableNode (a)
    FalseValue:
    VariableNode (b)
```
![Результат работы 1](https://github.com/anna-1225/lab_5/blob/main/Resources/treee.png)
## Формат вывода
После нажатия кнопки пуск:
* выполняется анализ
* отображается AST
* выводятся ошибки с позициями






