import networkx as nx
import pydot
import re

# ----------------------------------------------------------
# Step 1: Parse DOT file safely
# ----------------------------------------------------------
def load_cfg(dot_file):
    graphs = pydot.graph_from_dot_file(dot_file)
    graph = graphs[0]   # take the first graph

    G = nx.DiGraph()

    # Add nodes
    for node in graph.get_nodes():
        name = node.get_name().strip('"')
        if name in ("node", "graph", "edge"):  # skip dot defaults
            continue
        label = node.get_label()
        if label:
            label = label.strip('"')
        else:
            label = name
        G.add_node(name, label=label)

    # Add edges
    for edge in graph.get_edges():
        src = edge.get_source().strip('"')
        dst = edge.get_destination().strip('"')
        G.add_edge(src, dst)

    return G

# ----------------------------------------------------------
# Step 2: Identify definitions (x = ...)
# ----------------------------------------------------------
def extract_definitions(G):
    definitions = {}
    def_id = 1

    for node, data in G.nodes(data=True):
        label = data.get("label", "")
        defs = []

        for line in label.split("\\n"):
            line = line.strip().strip(";")
            var = None

            # Skip empty lines and labels
            if not line or line.endswith(":"):
                continue

            # 1. Regular assignment
            if "=" in line and not line.startswith("//"):
                var = line.split("=")[0].strip()

            # 2. scanf assignment - improved parsing
            elif "scanf" in line:
                # Extract variable from scanf("%d", &choice);
                match = re.search(r'&(\w+)', line)
                if match:
                    var = match.group(1)
                else:
                    # Fallback: try to extract from parentheses
                    parts = line.split('(')
                    if len(parts) > 1:
                        var = parts[1].split(')')[0].replace('&', '').strip()

            # 3. Function calls - handle case statements properly
            elif "(" in line and not line.startswith("//"):
                # Extract just the function name from case statements
                if "case" in line or "default" in line:
                    # Extract function call from "case X: func();" or "default: func();"
                    if ":" in line:
                        func_part = line.split(":")[1].strip()
                        func = func_part.split("(")[0].strip()
                    else:
                        func = line.split("(")[0].strip()
                else:
                    func = line.split("(")[0].strip()

                # Map functions to logical variables
                func_map = {
                    "addStudent": "studentDB",
                    "displayStudents": "studentDB", 
                    "searchStudent": "studentDB",
                    "updateMarks": "studentDB", 
                    "deleteStudent": "studentDB",
                    "printf": "output",
                    "switch": "menu",
                    "print": "output",
                    "scanf": "input"
                }
                
                if func in func_map:
                    var = func_map[func]
                elif func not in ["if", "while", "for", "return", "case", "default", "exit"]:
                    var = func

            if var:
                dname = f"D{def_id}"
                # Clean up the line text for better readability
                clean_line = line
                if ":" in line and ("case" in line or "default" in line):
                    clean_line = line.split(":")[1].strip()
                definitions[dname] = (node, var, clean_line)
                defs.append((dname, var))
                def_id += 1

        G.nodes[node]["defs"] = defs

    return definitions

# ----------------------------------------------------------
# Step 3: Compute gen/kill sets
# ----------------------------------------------------------
def compute_gen_kill(G, definitions):
    print(f"\nDEBUG: Total definitions found: {len(definitions)}")
    for d, (n, v, line) in definitions.items():
        print(f"  {d}: {v} = {line} (block {n})")
    
    for node, data in G.nodes(data=True):
        gen = set(d for d, v in data.get("defs", []))
        kill = set()
        
        # Get variables defined in this block
        vars_here = [v for _, v in data.get("defs", [])]
        print(f"\nDEBUG: Block {node} defines variables: {vars_here}")
        print(f"DEBUG: Block {node} has gen set: {gen}")
        
        # kill all other definitions of same variable
        for d, (n, v, line) in definitions.items():
            if v in vars_here and d not in gen:
                print(f"DEBUG: Adding {d} ({v}) to kill set for block {node}")
                kill.add(d)
        
        G.nodes[node]["gen"] = gen
        G.nodes[node]["kill"] = kill

        print(f"Block {node}: gen={gen}, kill={kill}")

# ----------------------------------------------------------
# Step 4: Iterative reaching definitions
# ----------------------------------------------------------
def reaching_definitions(G):
    for node in G.nodes():
        G.nodes[node]["in"] = set()
        G.nodes[node]["out"] = set()

    iteration = 0
    changed = True
    while changed:
        changed = False
        iteration += 1
        print(f"\nIteration {iteration}")
        print(f"{'Block':<6} {'gen[B]':<15} {'kill[B]':<15} {'in[B]':<20} {'out[B]':<20}")
        print("-" * 80)

        for node in G.nodes():
            preds = list(G.predecessors(node))

            # in[B] = union of out[P] for all predecessors P
            in_set = set()
            for p in preds:
                in_set |= G.nodes[p]["out"]

            # out[B] = gen[B] ∪ (in[B] – kill[B])
            out_set = G.nodes[node]["gen"] | (in_set - G.nodes[node]["kill"])

            # check if changed
            if in_set != G.nodes[node]["in"] or out_set != G.nodes[node]["out"]:
                changed = True
                G.nodes[node]["in"] = in_set
                G.nodes[node]["out"] = out_set

            gen = ",".join(sorted(G.nodes[node]["gen"]))
            kill = ",".join(sorted(G.nodes[node]["kill"]))
            inb = ",".join(sorted(G.nodes[node]["in"]))
            outb = ",".join(sorted(G.nodes[node]["out"]))
            print(f"{node:<6} {gen:<15} {kill:<15} {inb:<20} {outb:<20}")

    return G

# ----------------------------------------------------------
# Step 5: Print mapping of definitions
# ----------------------------------------------------------
def print_definitions(definitions):
    print("\nDefinitions mapping:")
    for d, (n, v, line) in definitions.items():
        print(f"  {d}: {line}  (block {n}, var={v})")

# ----------------------------------------------------------
# Main
# ----------------------------------------------------------
if __name__ == "__main__":
    dot_file = "program1.dot"   # change to program2.dot / program3.dot
    G = load_cfg(dot_file)
    definitions = extract_definitions(G)
    compute_gen_kill(G, definitions)
    print_definitions(definitions)
    G = reaching_definitions(G)