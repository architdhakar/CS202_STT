import pandas as pd
from itertools import combinations

try:
    df = pd.read_csv('aggregated_results.csv')
except FileNotFoundError:
    print("Error: `aggregated_results.csv` not found.")
    print("Please run `process_results.py` first to generate it.")
    exit()

tools = df['Tool_Name'].unique().tolist()
print(f"Analyzing results for tools: {', '.join(tools)}\n")


print("## Tool-level CWE Coverage Analysis")
print("---------------------------------------")
for tool in tools:
    # Filter for the current tool
    tool_df = df[df['Tool_Name'] == tool]
    
    # Find the unique CWEs that are in the Top 25
    top_25_found = tool_df[tool_df['Is_In_CWE_Top_25?'] == True]['CWE_ID'].nunique()
    
    # Calculate coverage percentage
    coverage_percent = (top_25_found / 25) * 100
    
    print(f"-> {tool.title()}:")
    print(f"   - Found {top_25_found} out of 25 Top CWEs.")
    print(f"   - Coverage: {coverage_percent:.2f}%\n")

print("\n## Pairwise Agreement (Jaccard Index / IoU)")
print("-------------------------------------------------")
# Get the unique set of CWEs for each tool
cwe_sets = {tool: set(df[df['Tool_Name'] == tool]['CWE_ID']) for tool in tools}

# Get all unique pairs of tools
tool_pairs = list(combinations(tools, 2))

# Store results to find the best combo later
iou_results = {}

for tool1, tool2 in tool_pairs:
    set1 = cwe_sets[tool1]
    set2 = cwe_sets[tool2]
    
    intersection = len(set1.intersection(set2))
    union = len(set1.union(set2))
    
    iou = intersection / union if union > 0 else 0
    iou_results[(tool1, tool2)] = iou
    
    print(f"-> {tool1.title()} vs. {tool2.title()}:")
    print(f"   - Intersection (shared CWEs): {intersection}")
    print(f"   - Union (total unique CWEs): {union}")
    print(f"   - Jaccard Index (IoU): {iou:.4f}\n")


print("\n## Conclusion & Recommendation")
print("-----------------------------------")
if not iou_results:
    print("Could not generate a recommendation as only one tool was analyzed.")
else:
    # Find the tool pair with the lowest IoU (least overlap)
    best_pair, min_iou = min(iou_results.items(), key=lambda item: item[1])
    
    print(f"The tool combination with the lowest overlap (most complementary) is:")
    print(f"**{best_pair[0].title()} and {best_pair[1].title()}** with an IoU of {min_iou:.4f}.")
    print("\nThis pair maximizes CWE coverage because the tools find different types of vulnerabilities.")