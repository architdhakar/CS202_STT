"""
Simple arithmetic operations script.
Demonstrates addition, subtraction, multiplication, and division,
and prints results along with their types.
"""

def add(a, b):
    """Add two numbers."""
    return a + b

def subtract(a, b):
    """Subtract two numbers."""
    return a - b

def multiply(a, b):
    """Multiply two numbers."""
    return a * b

def divide(a, b):
    """Divide two numbers."""
    if b == 0:
        return "Error: Division by zero"
    return a / b

# Example numbers (constants by pylint's convention)
X = 10
Y = 5

# Perform operations
SUM_RESULT = add(X, Y)
SUB_RESULT = subtract(X, Y)
MUL_RESULT = multiply(X, Y)
DIV_RESULT = divide(X, Y)

# Print results
print("Addition:", SUM_RESULT, "| Type:", type(SUM_RESULT))
print("Subtraction:", SUB_RESULT, "| Type:", type(SUB_RESULT))
print("Multiplication:", MUL_RESULT, "| Type:", type(MUL_RESULT))
print("Division:", DIV_RESULT, "| Type:", type(DIV_RESULT))

print("\nAll operations completed successfully!")
