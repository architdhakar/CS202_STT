import csv
import json
import os
import re
from tabulate import tabulate

# --- CWE Top 25 (2024) ---
CWE_TOP_25 = {
    "CWE-79", "CWE-89", "CWE-416", "CWE-78", "CWE-20", "CWE-125", "CWE-22",
    "CWE-352", "CWE-434", "CWE-862", "CWE-476", "CWE-287", "CWE-190",
    "CWE-502", "CWE-787", "CWE-119", "CWE-918", "CWE-77", "CWE-306",
    "CWE-94", "CWE-269", "CWE-863", "CWE-400", "CWE-362", "CWE-276"
}

def parse_bandit(file_path):
    findings = {}
    with open(file_path, 'r') as f:
        data = json.load(f)
    for result in data.get('results', []):
        cwe_id = result.get('issue_cwe', {}).get('id')
        if cwe_id:
            cwe_str = f"CWE-{cwe_id}"
            findings[cwe_str] = findings.get(cwe_str, 0) + 1
    return findings


def parse_semgrep(file_path):
    findings = {}
    with open(file_path, 'r') as f:
        data = json.load(f)
    for result in data.get('results', []):
        cwe_list = result.get('extra', {}).get('metadata', {}).get('cwe', [])
        if cwe_list and isinstance(cwe_list[0], str):
            match = re.search(r'CWE-\d+', cwe_list[0])
            if match:
                cwe_str = match.group(0)
                findings[cwe_str] = findings.get(cwe_str, 0) + 1
    return findings

def parse_pip_audit(file_path):
    findings = {}
    with open(file_path, 'r') as f:
        data = json.load(f)

    found_any = False
    for dep in data.get('dependencies', []):
        for vuln in dep.get('vulns', []):
            found_any = True
            cwe_id = "CWE-937"  # Vulnerable third-party component
            findings[cwe_id] = findings.get(cwe_id, 0) + 1

    # Even if none found, record a 0 finding so pip-audit appears in CSV
    if not found_any:
        findings["CWE-937"] = 0

    return findings

projects = ['seaborn', 'django', 'flask']
tools = {
    'bandit': parse_bandit,
    'semgrep': parse_semgrep,
    'pipaudit': parse_pip_audit
}

all_data = []

for project in projects:
    for tool, parser in tools.items():
        file_path = f"{tool}_{project}.json"
        if os.path.exists(file_path):
            print(f"-> Processing {project} with {tool}...")
            results = parser(file_path)
            for cwe, count in results.items():
                all_data.append({
                    'Project_Name': project,
                    'Tool_Name': tool,
                    'CWE_ID': cwe,
                    'Number_of_Findings': count,
                    'Is_In_CWE_Top_25?': cwe in CWE_TOP_25
                })
        else:
            print(f" Skipping {project} with {tool}: file not found ({file_path})")

if not all_data:
    print("\n No data processed — please check if JSON files exist.")
else:
    output_file = 'aggregated_results.csv'
    with open(output_file, 'w', newline='', encoding='utf-8') as f:
        writer = csv.DictWriter(f, fieldnames=all_data[0].keys())
        writer.writeheader()
        writer.writerows(all_data)
    print(f"\n Success! Results saved to `{output_file}`")
    print(tabulate(all_data, headers="keys", tablefmt="grid"))