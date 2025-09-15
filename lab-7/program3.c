#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_ACCOUNTS 100
#define NAME_LEN 50

typedef struct {
    int accNo;
    char name[NAME_LEN];
    float balance;
} Account;

Account accounts[MAX_ACCOUNTS];
int accountCount = 0;

void createAccount() {
    if (accountCount >= MAX_ACCOUNTS) {
        printf("Bank limit reached!\n");
        return;
    }
    Account a;
    printf("Enter Account Number: ");
    scanf("%d", &a.accNo);
    getchar();
    printf("Enter Name: ");
    fgets(a.name, NAME_LEN, stdin);
    a.name[strcspn(a.name, "\n")] = 0;
    a.balance = 0.0;
    accounts[accountCount++] = a;
    printf("Account created successfully!\n");
}

void displayAccounts() {
    if (accountCount == 0) {
        printf("No accounts available.\n");
        return;
    }
    printf("\n--- Account List ---\n");
    for (int i = 0; i < accountCount; i++) {
        printf("AccNo: %d, Name: %s, Balance: %.2f\n", accounts[i].accNo, accounts[i].name, accounts[i].balance);
    }
}

void deposit() {
    int accNo;
    float amount;
    printf("Enter Account Number: ");
    scanf("%d", &accNo);
    printf("Enter Amount to Deposit: ");
    scanf("%f", &amount);
    for (int i = 0; i < accountCount; i++) {
        if (accounts[i].accNo == accNo) {
            accounts[i].balance += amount;
            printf("Deposit successful! New Balance: %.2f\n", accounts[i].balance);
            return;
        }
    }
    printf("Account not found!\n");
}

void withdraw() {
    int accNo;
    float amount;
    printf("Enter Account Number: ");
    scanf("%d", &accNo);
    printf("Enter Amount to Withdraw: ");
    scanf("%f", &amount);
    for (int i = 0; i < accountCount; i++) {
        if (accounts[i].accNo == accNo) {
            if (accounts[i].balance < amount) {
                printf("Insufficient balance!\n");
            } else {
                accounts[i].balance -= amount;
                printf("Withdrawal successful! New Balance: %.2f\n", accounts[i].balance);
            }
            return;
        }
    }
    printf("Account not found!\n");
}

void checkBalance() {
    int accNo;
    printf("Enter Account Number: ");
    scanf("%d", &accNo);
    for (int i = 0; i < accountCount; i++) {
        if (accounts[i].accNo == accNo) {
            printf("Account: %d, Name: %s, Balance: %.2f\n", accounts[i].accNo, accounts[i].name, accounts[i].balance);
            return;
        }
    }
    printf("Account not found!\n");
}

int main() {
    int choice;
    while (1) {
        printf("\n--- Bank Management System ---\n");
        printf("1. Create Account\n2. Display Accounts\n3. Deposit\n4. Withdraw\n5. Check Balance\n6. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        if (choice == 6) {
            printf("Exiting...\n");
            break;
        }

        switch (choice) {
            case 1: createAccount(); break;
            case 2: displayAccounts(); break;
            case 3: deposit(); break;
            case 4: withdraw(); break;
            case 5: checkBalance(); break;
            default: printf("Invalid choice!\n");
        }
    }
    return 0;
}
