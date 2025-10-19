import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from itertools import combinations

# --- SETUP ---
try:
    df = pd.read_csv('aggregated_results.csv')
except FileNotFoundError:
    print("Error: `aggregated_results.csv` not found. Please run the processing script first.")
    exit()

tools = sorted(df['Tool_Name'].unique())

# --- 1. PLOT: CWE TOP 25 COVERAGE BAR CHART ---

print("Generating CWE Top 25 Coverage bar chart...")

coverage_data = []
for tool in tools:
    tool_df = df[df['Tool_Name'] == tool]
    top_25_found = tool_df[tool_df['Is_In_CWE_Top_25?'] == True]['CWE_ID'].nunique()
    coverage_percent = (top_25_found / 25) * 100
    coverage_data.append({'Tool': tool.title(), 'Coverage (%)': coverage_percent})

coverage_df = pd.DataFrame(coverage_data).sort_values('Coverage (%)', ascending=False)

plt.style.use('seaborn-v0_8-whitegrid')
fig, ax = plt.subplots(figsize=(10, 6))

bars = ax.bar(coverage_df['Tool'], coverage_df['Coverage (%)'], color=['#4c72b0', '#55a868', '#c44e52'])
ax.set_title('CWE Top 25 Coverage by Tool', fontsize=16, fontweight='bold')
ax.set_ylabel('Coverage (%)', fontsize=12)
ax.set_ylim(0, max(coverage_df['Coverage (%)']) * 1.2 if max(coverage_df['Coverage (%)']) > 0 else 10)
ax.set_xlabel('Tool', fontsize=12)

# Add percentage labels on top of bars
for bar in bars:
    yval = bar.get_height()
    ax.text(bar.get_x() + bar.get_width()/2.0, yval + 0.5, f'{yval:.2f}%', ha='center', va='bottom')

plt.tight_layout()
plt.savefig('cwe_coverage_chart.png')
print("-> Saved 'cwe_coverage_chart.png'")


# --- 2. PLOT: PAIRWISE AGREEMENT (IOU) HEATMAP ---

print("\nGenerating Pairwise Agreement (IoU) heatmap...")

cwe_sets = {tool: set(df[df['Tool_Name'] == tool]['CWE_ID']) for tool in tools}
iou_matrix = pd.DataFrame(index=tools, columns=tools, dtype=float)

for tool1 in tools:
    for tool2 in tools:
        if tool1 == tool2:
            iou_matrix.loc[tool1, tool2] = 1.0
        else:
            set1 = cwe_sets[tool1]
            set2 = cwe_sets[tool2]
            intersection = len(set1.intersection(set2))
            union = len(set1.union(set2))
            iou = intersection / union if union > 0 else 0
            iou_matrix.loc[tool1, tool2] = iou

plt.figure(figsize=(8, 6))
sns.heatmap(iou_matrix, annot=True, cmap='viridis', fmt=".4f", linewidths=.5)
plt.title('Tool Agreement (Jaccard Index / IoU Matrix)', fontsize=16, fontweight='bold')
plt.xticks(rotation=0)
plt.yticks(rotation=0)

plt.tight_layout()
plt.savefig('iou_heatmap.png')
print("-> Saved 'iou_heatmap.png'")