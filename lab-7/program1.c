#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_STUDENTS 100
#define NAME_LEN 50

typedef struct {
    int roll;
    char name[NAME_LEN];
    float marks;
} Student;

Student students[MAX_STUDENTS];
int studentCount = 0;

void addStudent() {
    if (studentCount >= MAX_STUDENTS) {
        printf("Student limit reached!\n");
        return;
    }
    Student s;
    printf("Enter Roll Number: ");
    scanf("%d", &s.roll);
    printf("Enter Name: ");
    getchar();
    fgets(s.name, NAME_LEN, stdin);
    s.name[strcspn(s.name, "\n")] = 0;
    printf("Enter Marks: ");
    scanf("%f", &s.marks);
    students[studentCount++] = s;
    printf("Student added successfully!\n");
}

void displayStudents() {
    if (studentCount == 0) {
        printf("No students to display.\n");
        return;
    }
    printf("\n--- Student List ---\n");
    for (int i = 0; i < studentCount; i++) {
        printf("Roll: %d, Name: %s, Marks: %.2f\n", students[i].roll, students[i].name, students[i].marks);
    }
}

void searchStudent() {
    int roll;
    printf("Enter roll number to search: ");
    scanf("%d", &roll);
    for (int i = 0; i < studentCount; i++) {
        if (students[i].roll == roll) {
            printf("Found: Roll: %d, Name: %s, Marks: %.2f\n", students[i].roll, students[i].name, students[i].marks);
            return;
        }
    }
    printf("Student not found!\n");
}

void updateMarks() {
    int roll;
    float newMarks;
    printf("Enter roll number to update marks: ");
    scanf("%d", &roll);
    for (int i = 0; i < studentCount; i++) {
        if (students[i].roll == roll) {
            printf("Enter new marks: ");
            scanf("%f", &newMarks);
            students[i].marks = newMarks;
            printf("Marks updated successfully!\n");
            return;
        }
    }
    printf("Student not found!\n");
}

void deleteStudent() {
    int roll;
    printf("Enter roll number to delete: ");
    scanf("%d", &roll);
    for (int i = 0; i < studentCount; i++) {
        if (students[i].roll == roll) {
            for (int j = i; j < studentCount - 1; j++) {
                students[j] = students[j + 1];
            }
            studentCount--;
            printf("Student deleted successfully!\n");
            return;
        }
    }
    printf("Student not found!\n");
}

int main() {
    int choice;
    while (1) {
        printf("\n--- Student Management System ---\n");
        printf("1. Add Student\n2. Display Students\n3. Search Student\n4. Update Marks\n5. Delete Student\n6. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        if (choice == 6) {
            printf("Exiting...\n");
            break;
        }

        switch (choice) {
            case 1: addStudent(); break;
            case 2: displayStudents(); break;
            case 3: searchStudent(); break;
            case 4: updateMarks(); break;
            case 5: deleteStudent(); break;
            default: printf("Invalid choice!\n");
        }
    }
    return 0;
}
