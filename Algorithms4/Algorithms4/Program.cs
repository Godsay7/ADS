using Algorithms4;
using Lvl2;

Student myStudent1 = new Student("John", "Doe", 101, 3.5, 11);
Student myStudent2 = new Student("Jane", "Smith", 102, 3.8, 15);
Student myStudent3 = new Student("Alice", "Johnson", 101, 3.2, 0);
Student myStudent4 = new Student("Bob", "Brown", 102, 3.9, 9);
Student myStudent5 = new Student("Charlie", "Davis", 101, 3.7, 20);
Student myStudent6 = new Student("Eve", "Miller", 102, 3.7, 7);
int[] arr = { myStudent1.MissedLessons, myStudent2.MissedLessons, myStudent3.MissedLessons,
    myStudent4.MissedLessons, myStudent5.MissedLessons, myStudent6.MissedLessons };
Print.PrintArray(arr);
ShellSort.Sort(arr);
Print.PrintArray(arr);

MyLinkedList<Student> myLinkedList = new MyLinkedList<Student>();
myLinkedList.AddLast(myStudent1);
myLinkedList.AddLast(myStudent2);
myLinkedList.AddLast(myStudent3);
myLinkedList.AddLast(myStudent4);
myLinkedList.AddLast(myStudent5);
myLinkedList.AddLast(myStudent6);
myLinkedList.DisplayList();
myLinkedList.BubbleSort();
myLinkedList.DisplayList();

int[] arr2 = { myStudent1.MissedLessons, myStudent2.MissedLessons, myStudent3.MissedLessons,
    myStudent4.MissedLessons, myStudent5.MissedLessons, myStudent6.MissedLessons };
Print.PrintArray(arr2);
MyMergeSort.MergeSort(arr2);
Print.PrintArray(arr2);