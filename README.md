# Prototype

## Постановка задачи

### Цель

Создать иерархию из нескольких классов, в которых реализованы методы клонирования объектов по шаблону проектирования "Прототип".

### Описание

0. Придумать и создать 3-4 класса, которые наследуются как минимум дважды, и написать их краткое описание текстом.

1. Создать свой дженерик интерфейс IMyCloneable для реализации шаблона "Прототип".

2. Сделать возможность клонирования объекта для каждого из этих классов, используя вызовы родительских конструкторов.

3. Составить тесты или написать программу для демонстрации функции клонирования.

4. Добавить к каждому классу реализацию стандартного интерфейса ICloneable и реализовать его функционал через уже созданные методы.

5. Написать вывод: какие преимущества и недостатки у каждого из интерфейсов: IMyCloneable и ICloneable.

## Результаты

### Описание классов

Система D&D 5e имеет слишком много несущественных для задания деталей, потому выбрана гораздо более общая идея на тему RPG.

#### Здоровье

Health &mdash; специализированный класс для хранения очков здоровья существ.<br/>
Здоровье может принимать значения от нуля до максимума очков здоровья, задающегося при создании инстанса.<br/>
Реализован для демонстрации возможностей Deep Copy.

#### Существа

Creature &mdash; базовый, но не абстрактный класс для существ, то есть в иерархии находится на нулевом уровне.<br/>
Существо обладает именем, здоровьем и возможностью совершать атаку.

Bandit &mdash; класс-наследник базового Creature, то есть в иерархии находится на первом уровне.<br/>
Помимо уникальной атаки, бандит имеет некоторое количество золотых монет.

BanditArcher &mdash; класс-наследник класса Bandit, то есть в иерархии находится на втором уровне.<br/>
Отличается от рядового бандита только уникальной атакой.

Elemental &mdash; класс-наследник базового Creature, то есть, как и Bandit, в иерархии находится на первом уровне.<br/>
Помимо уникальной атаки, имеет уникальное свойство Element, указывающее на тип элементали (огненная, водяная и т.д.).<br/>
Не требует ручного присваивания имени (у элементалей недостаточно развита самоидентификация).

Для удобства клонирования все наследники Creature поддерживают конструктор с полным объектом Health.<br/>
Это позволяет абстрагироваться от деталей реализации конструктора Health в верхнеуровневых классах.

### Демонстрация клонирования

#### Вывод в консоль

Примечательно, &mdash; однако довольно неудобно, &mdash; что стандартный Clone() не позволяет пользоваться методами клонированного объекта "из коробки" (в примере &mdash; Attack()).

<pre>
Cloning a previously damaged creature

Cloning Creature...
Original: Creature, HP: 15/20
Cloned: Creature, HP: 15/20
Changing original Creature...
Original: Creature, HP: 10/20
Cloned: Creature, HP: 15/20
Demonstrating clone attacks...
Producing basic attack.
Producing basic attack.

Cloning a Bandit

Cloning Bandit...
Original: Bandit Bob, HP: 30/30 with 0 gold coins
Cloned: Bandit Bob, HP: 30/30 with 0 gold coins
Changing original Bandit...
Original: Bandit Bob, HP: 25/30 with 0 gold coins
Cloned: Bandit Bob, HP: 30/30 with 0 gold coins

Cloning a Bandit Archer: including ICloneable

Cloning BanditArcher...
Original: Archer Paul, HP: 20/20 with 10 gold coins
Cloned: Archer Paul, HP: 20/20 with 10 gold coins
Demonstrating clone attacks...
Archer stealthily shoots an arrow!
Archer stealthily shoots an arrow!

Cloning an Elemental

Cloning Elemental...
Original: Earth Elemental, HP: 60/60
Cloned: Earth Elemental, HP: 60/60
Demonstrating clone attacks...
Crushing!
Scorching!
</pre>

#### Тесты

Тесты написаны для Health, Creature и Bandit.<br/>
Особо примечательны:
* сравнения Is.SameAs(), позволяющие убедиться, что клон не является оригинальным объектом;
* сравнения Is.EqualTo(), позволяющие убедиться, что клон является точной копией оригинала;
* проверки значений Health.Current, позволяющие убедиться, что клонирование является Deep Copy.

### Плюсы и минусы I(My)Cloneable

#### IMyCloneable

##### Плюсы

* Типобезопасность (тип объекта-копии совпадает с типом оригинала).
* Можно реализовать по-разному для любого уровня иерархии.
* Можно кастомизировать имя метода для клонирования.

##### Минусы

* Не является стандартным интерфейсом.
* Требуется собственная реализация для каждого уровня иерархии.

#### ICloneable

##### Плюсы

* Стандартный интерфейс, вшитый в .NET Framework.
* Требуется только одна реализация (в базовом классе иерархии).

##### Минусы

* Возвращает тип object, &mdash; для нормального использования требуется приведение типов.
* Нет проверки типа до компиляции.
* Clone может оказаться определён как shallow copy, так и как deep copy.
