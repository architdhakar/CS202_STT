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

# Example numbers
x = 10
y = 5

# Perform operations
sum_result = add(x, y)
sub_result = subtract(x, y)
mul_result = multiply(x, y)
div_result = divide(x, y)

# Print results
print("Addition:", sum_result, "| Type:", type(sum_result))
print("Subtraction:", sub_result, "| Type:", type(sub_result))
print("Multiplication:", mul_result, "| Type:", type(mul_result))
print("Division:", div_result, "| Type:", type(div_result))

print("\nAll operations completed successfully!")
